    select s.Id, 
	       s.Name, 
		   s.Description, 
		   s.Address, 
		   s.Phone, 
		   s.DocumentId , 
		   s.Active
	  from Shop s
	 where s.Id = @Id;
 