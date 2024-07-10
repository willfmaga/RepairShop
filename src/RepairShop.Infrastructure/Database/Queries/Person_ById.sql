    select p.Id, p.Name, p.Surname, p.BirthDate, p.TypeId, p.DocumentId 
	  from Person p
	 where Id = @Id;
 