INSERT INTO Person(Name, 
			Surname, 
			BirthDate, 
			TypeId, 
			DocumentId,
			CreationDate)
	VALUES (@Name, 
			@Surname, 
			@BirthDate, 
			@TypeId, 
			@DocumentId,
			@CreationDate
			);


SELECT LAST_INSERT_ID();