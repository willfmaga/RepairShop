INSERT INTO Person(Name, 
			Surname, 
			BirthDate, 
			TypeId, 
			DocumentId)
	VALUES (@Name, 
			@Surname, 
			@BirthDate, 
			@TypeId, 
			@DocumentId);


SELECT LAST_INSERT_ID();