INSERT INTO Shop(Name, Description, Address, Phone, Document, CreationDate)
     VALUES (@Name, @Description, @Address, @Phone, @Document, @CreationDate);


SELECT LAST_INSERT_ID();