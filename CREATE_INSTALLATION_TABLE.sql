-- Option 2: Create a dedicated installation table
-- Run this SQL in your phpMyAdmin or MySQL client

CREATE TABLE `installation` (
  `installation_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `customer_id` int(10) NOT NULL,
  `staff_id` int(10) UNSIGNED DEFAULT NULL,
  `installation_date` date NOT NULL,
  `scheduled_date` date DEFAULT NULL,
  `completion_date` date DEFAULT NULL,
  `installation_address` text NOT NULL,
  `equipment_used` text DEFAULT NULL,
  `technician_notes` text DEFAULT NULL,
  `status` enum('Pending','In Progress','Completed','Cancelled') NOT NULL DEFAULT 'Pending',
  `service_cost` decimal(8,2) NOT NULL DEFAULT 0.00,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`installation_id`),
  KEY `installation_customer_id_index` (`customer_id`),
  KEY `installation_staff_id_index` (`staff_id`),
  CONSTRAINT `installation_customer_id_foreign` FOREIGN KEY (`customer_id`) REFERENCES `customer` (`customer_id`),
  CONSTRAINT `installation_staff_id_foreign` FOREIGN KEY (`staff_id`) REFERENCES `staff` (`staff_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Add some sample data (optional)
INSERT INTO `installation` (`customer_id`, `installation_date`, `scheduled_date`, `installation_address`, `status`, `service_cost`) VALUES
(1, '2025-11-05', '2025-11-05', 'Default Installation Address', 'Completed', 500.00),
(3, '2025-11-22', '2025-11-22', 'Default Installation Address', 'In Progress', 500.00);


