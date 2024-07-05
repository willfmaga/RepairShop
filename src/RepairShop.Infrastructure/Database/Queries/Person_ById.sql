    select p.Id, p.Name, p.Surname, p.BirthDate, p.Type, p.DocumentId 
	  from Person p
	 where Id = @Id;
 