SELECT * FROM Orders
--Khách hàng hủy đơn hàng
EXEC USP_21424031_CancelOrder_LU 7
SELECT * FROM Orders