Imports System.Net
Imports System.IO
Imports System.Collections.Specialized
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports MySqlConnector

' --- 1. SHARED STATE MODULE (UPDATED for Phone Number) ---
Module GlobalState
    ' IMPORTANT: Update this to your correct API base URL
    Public Const BaseUrl As String = "http://127.0.0.1/sparx-api/"
    Public ReadOnly CONNECTION_STRING As String = "Server=127.0.0.1;Port=3306;Database=sparx;User ID=root;Password=;SslMode=Preferred;"

    ' Semaphore SMS API Configuration
    Public Const SEMAPHORE_API_KEY As String = "3d81194ec2cf0d9b33c8221724d35887"
    Public Const SEMAPHORE_API_URL As String = "https://api.semaphore.co/api/v4/messages"
    Public Const SEMAPHORE_SENDER_NAME As String = "sparxfiber"

    ' Stores the email address being used for the current password reset attempt
    Public UserEmail As String = String.Empty
    ' Stores the phone number being used for the current password reset attempt
    Public UserPhoneNumber As String = String.Empty
    ' Stores the verification code for local checking
    Public VerificationCode As String = String.Empty
    ' NEW: Store the username from the login form for forgot password
    Public ForgotPasswordUsername As String = String.Empty

    Public Sub ClearForgotPasswordState()
        ForgotPasswordUsername = String.Empty
        UserPhoneNumber = String.Empty
        VerificationCode = String.Empty
    End Sub
End Module

' --- 2. API CLIENT MODULE (UPDATED with username support) ---
Module APIService
    ' FIX 1: Return simple tuple without names to avoid destructuring issues - Simple string parsing
    Private Function ParseResponse(json As String) As (Boolean, String)
        Try
            ' Simple string parsing to extract success and message
            Dim success As Boolean = json.Contains("""success"":true")
            Dim messageStart = json.IndexOf("""message"":")
            If messageStart = -1 Then Return (False, "Invalid response format")

            messageStart += 11 ' Length of "message":"
            Dim messageEnd = json.IndexOf("""", messageStart)
            If messageEnd = -1 Then messageEnd = json.IndexOf("}", messageStart)

            Dim responseMessage = json.Substring(messageStart, messageEnd - messageStart).Trim(""""c)
            Return (success, responseMessage)
        Catch ex As Exception
            Return (False, "Error parsing API response: " & ex.Message & vbCrLf & "Raw response: " & json)
        End Try
    End Function

    ' NEW: Send code with both username and phone number
    Public Async Function SendCodeAsync(username As String, phoneNumber As String, purpose As String) As Task(Of (Boolean, String))
        Return Await Task.Run(Function() As (Boolean, String)
                                  Try
                                      Using client As New Net.WebClient()
                                          client.Headers.Add("Content-Type", "application/x-www-form-urlencoded")

                                          Dim postData As New NameValueCollection()
                                          postData.Add("username", username) ' Add username
                                          postData.Add("email", phoneNumber) ' Phone number as email field
                                          postData.Add("purpose", purpose)

                                          Dim responseBytes = client.UploadValues(GlobalState.BaseUrl & "send_code.php", "POST", postData)
                                          Dim response As String = System.Text.Encoding.UTF8.GetString(responseBytes)

                                          ' Parse JSON response
                                          Dim json As Object = Newtonsoft.Json.JsonConvert.DeserializeObject(response)
                                          If json("success") Then
                                              Return (True, json("message").ToString())
                                          Else
                                              Return (False, json("message").ToString())
                                          End If
                                      End Using
                                  Catch ex As Exception
                                      Return (False, $"Error sending code: {ex.Message}")
                                  End Try
                              End Function)
    End Function

    ' Original: For backward compatibility
    Public Async Function SendCodeAsync(identifier As String, purpose As String) As Task(Of (Boolean, String))
        Return Await Task.Run(Function() As (Boolean, String)
                                  Try
                                      Using client As New Net.WebClient()
                                          client.Headers.Add("Content-Type", "application/x-www-form-urlencoded")

                                          Dim postData As New NameValueCollection()
                                          postData.Add("email", identifier) ' Phone number as email field
                                          postData.Add("purpose", purpose)

                                          Dim responseBytes = client.UploadValues(GlobalState.BaseUrl & "send_code.php", "POST", postData)
                                          Dim response As String = System.Text.Encoding.UTF8.GetString(responseBytes)

                                          ' Parse JSON response
                                          Dim json As Object = Newtonsoft.Json.JsonConvert.DeserializeObject(response)
                                          If json("success") Then
                                              Return (True, json("message").ToString())
                                          Else
                                              Return (False, json("message").ToString())
                                          End If
                                      End Using
                                  Catch ex As Exception
                                      Return (False, $"Error sending code: {ex.Message}")
                                  End Try
                              End Function)
    End Function

    ' NEW: Verify code with both username and phone number
    Public Async Function VerifyCodeAsync(username As String, phoneNumber As String, purpose As String, code As String) As Task(Of (Boolean, String))
        Return Await Task.Run(Function() As (Boolean, String)
                                  Try
                                      Using client As New Net.WebClient()
                                          client.Headers.Add("Content-Type", "application/x-www-form-urlencoded")

                                          Dim postData As New NameValueCollection()
                                          postData.Add("username", username) ' Add username
                                          postData.Add("email", phoneNumber) ' Phone number as email field
                                          postData.Add("purpose", purpose)
                                          postData.Add("code", code)

                                          Dim responseBytes = client.UploadValues(GlobalState.BaseUrl & "verify_code.php", "POST", postData)
                                          Dim response As String = System.Text.Encoding.UTF8.GetString(responseBytes)

                                          ' Parse JSON response
                                          Dim json As Object = Newtonsoft.Json.JsonConvert.DeserializeObject(response)
                                          If json("success") Then
                                              Return (True, json("message").ToString())
                                          Else
                                              Return (False, json("message").ToString())
                                          End If
                                      End Using
                                  Catch ex As Exception
                                      Return (False, $"Error verifying code: {ex.Message}")
                                  End Try
                              End Function)
    End Function

    ' Original: For backward compatibility
    Public Async Function VerifyCodeAsync(identifier As String, purpose As String, code As String) As Task(Of (Boolean, String))
        Return Await Task.Run(Function() As (Boolean, String)
                                  Try
                                      Using client As New Net.WebClient()
                                          client.Headers.Add("Content-Type", "application/x-www-form-urlencoded")

                                          Dim postData As New NameValueCollection()
                                          postData.Add("email", identifier) ' Phone number as email field
                                          postData.Add("purpose", purpose)
                                          postData.Add("code", code)

                                          Dim responseBytes = client.UploadValues(GlobalState.BaseUrl & "verify_code.php", "POST", postData)
                                          Dim response As String = System.Text.Encoding.UTF8.GetString(responseBytes)

                                          ' Parse JSON response
                                          Dim json As Object = Newtonsoft.Json.JsonConvert.DeserializeObject(response)
                                          If json("success") Then
                                              Return (True, json("message").ToString())
                                          Else
                                              Return (False, json("message").ToString())
                                          End If
                                      End Using
                                  Catch ex As Exception
                                      Return (False, $"Error verifying code: {ex.Message}")
                                  End Try
                              End Function)
    End Function

    ' NEW: Change password using username
    Public Async Function ChangePasswordAsync(username As String, newPassword As String) As Task(Of (Boolean, String))
        Return Await Task.Run(Function() As (Boolean, String)
                                  Try
                                      Using client As New Net.WebClient()
                                          client.Headers.Add("Content-Type", "application/x-www-form-urlencoded")

                                          Dim postData As New NameValueCollection()
                                          postData.Add("username", username) ' Use username to identify user
                                          postData.Add("new_password", newPassword)

                                          Dim responseBytes = client.UploadValues(GlobalState.BaseUrl & "change_password_forgot.php", "POST", postData)
                                          Dim response As String = System.Text.Encoding.UTF8.GetString(responseBytes)

                                          ' Parse JSON response
                                          Dim json As Object = Newtonsoft.Json.JsonConvert.DeserializeObject(response)
                                          If json("success") Then
                                              Return (True, json("message").ToString())
                                          Else
                                              Return (False, json("message").ToString())
                                          End If
                                      End Using
                                  Catch ex As Exception
                                      Return (False, $"Error changing password: {ex.Message}")
                                  End Try
                              End Function)
    End Function
End Module

