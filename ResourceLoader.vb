Imports System.Reflection
Imports System.Resources
Imports System.Drawing

Public Module ResourceLoader
    ''' <summary>
    ''' Load a bitmap resource by name from a referenced assembly.
    ''' Example: LoadBitmapFromAssembly("subscriber", GetType(SPARX_Management_System.SidePanel))
    ''' </summary>
    Public Function LoadBitmapFromAssembly(resourceName As String, typeInReferencedAssembly As Type) As Bitmap
        If String.IsNullOrWhiteSpace(resourceName) Then
            Throw New ArgumentException("resourceName required", NameOf(resourceName))
        End If
        If typeInReferencedAssembly Is Nothing Then
            Throw New ArgumentNullException(NameOf(typeInReferencedAssembly))
        End If

        Dim asm As Assembly = typeInReferencedAssembly.Assembly
        Dim candidateBaseNames As String() = {
            asm.GetName().Name & ".Resources",
            "SPARX_Management_System.Resources" ' keep as explicit fallback — adjust if your root namespace differs
        }

        For Each baseName In candidateBaseNames
            Try
                Dim rm As New ResourceManager(baseName, asm)
                Dim obj As Object = rm.GetObject(resourceName)
                Dim bmp As Bitmap = TryCast(obj, Bitmap)
                If bmp IsNot Nothing Then
                    Return bmp
                End If
            Catch ex As MissingManifestResourceException
                ' baseName not present in this assembly — try next
            End Try
        Next

        ' helpful diagnostic: list manifest resource names so you can find the correct base name
        Dim manifestNames = asm.GetManifestResourceNames()
        Dim msg = $"Resource '{resourceName}' not found via ResourceManager. Assembly manifest resources: {String.Join(", ", manifestNames)}"
        Throw New InvalidOperationException(msg)
    End Function
End Module
