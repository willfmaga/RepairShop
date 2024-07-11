    select p.Id, p.Name, p.Surname, p.BirthDate, p.TypeId, p.DocumentId ,p.CreationDate , p.Active
	  from Person p
inner join Document d 
		on d.Id = p.DocumentId 
	 where d.Value = @DocumentValue;
 