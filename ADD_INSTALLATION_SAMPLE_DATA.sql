-- Add sample installation data to the services table
-- Run this in phpMyAdmin or your MySQL client

-- First, check if you have customers (you need customer_id to exist)
-- Your customers are: customer_id 1 and 3

-- Add sample installation services
INSERT INTO `services` (
    `customer_id`, 
    `staff_id`, 
    `service_type`, 
    `date_requested`, 
    `status`, 
    `service_cost`, 
    `payment_method`
) VALUES
-- Completed installation
(1, 1, 'Installation', '2025-11-15', 'Completed', 500.00, 'Walk-in'),

-- In Progress installation
(3, 1, 'Installation', '2025-11-20', 'In Progress', 500.00, 'Walk-in'),

-- Requested installation
(1, 1, 'Installation', '2025-11-22', 'Requested', 500.00, 'Walk-in'),

-- Another Completed
(3, 1, 'Installation', '2025-11-10', 'Completed', 500.00, 'Walk-in'),

-- Another In Progress
(1, 1, 'Installation', '2025-11-21', 'In Progress', 500.00, 'Walk-in');

-- After running this, refresh your application and the pie chart should show:
-- - Completed: 2 (40%)
-- - In Progress: 2 (40%)
-- - Requested: 1 (20%)


