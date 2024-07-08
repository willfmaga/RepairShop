INSERT INTO Shop(Name, Description, Address, Phone, DocumentId)
     VALUES (@Name, @Description, @Address, @Phone, @DocumentId);


SELECT LAST_INSERT_ID();