SELECT Id,
	   Name, 
	   Price, 
	   CostPrice, 
	   TypeId,
	   CreationDate,
	   OnlyDisplay
  FROM Item
 WHERE TypeId = @TypeId; 


