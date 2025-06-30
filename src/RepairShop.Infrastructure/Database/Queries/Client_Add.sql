INSERT INTO Client(Name, 
			Surname, 
			BirthDate, 
			Document,
			CreationDate)
	VALUES (@Name, 
			@Surname, 
			@BirthDate, 
			@Document,
			@CreationDate
			);


SELECT LAST_INSERT_ID();