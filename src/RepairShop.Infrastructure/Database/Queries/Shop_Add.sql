INSERT INTO Shop(Name, Description, Address, Phone, DocumentId, CreationDate)
     VALUES (@Name, @Description, @Address, @Phone, @DocumentId, @CreationDate);


SELECT LAST_INSERT_ID();