SELECT Id,
	   Name, 
	   Price, 
	   CostPrice, 
	   TypeId,
	   CreationDate,
	   OnlyDisplay
  FROM Item
 WHERE Id = @Id; 


