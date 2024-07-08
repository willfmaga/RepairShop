    select s.Id, s.Name, s.Description, s.Address, s.Phone, s.DocumentId , s.Active
	  from Shop s
inner join Document d 
		on d.Id = s.DocumentId 
	 where d.Value = @DocumentValue;
 