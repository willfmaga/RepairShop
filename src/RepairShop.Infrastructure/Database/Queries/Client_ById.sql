    select c.Id, c.Name, c.Surname, c.BirthDate, c.Document ,c.CreationDate,  c.Active
	  from Client c
	 where Id = @Id;
 