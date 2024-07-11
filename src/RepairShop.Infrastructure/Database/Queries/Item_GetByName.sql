SELECT Id,
	   Name, 
	   Price, 
	   CostPrice, 
	   TypeId,
	   CreationDate,
	   OnlyDisplay
  FROM Item
 WHERE Name like CONCAT('%', @Name, '%'); 


