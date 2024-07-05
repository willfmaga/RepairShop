INSERT INTO Person(Name, Surname, BirthDate, Type, DocumentId)
	VALUES (@Name, @Surname, @BirthDate, @Type, @DocumentId);


SELECT LAST_INSERT_ID();