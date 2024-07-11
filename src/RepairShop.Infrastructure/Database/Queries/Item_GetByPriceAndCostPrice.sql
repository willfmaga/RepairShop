SELECT Id,
	   Name, 
	   Price, 
	   CostPrice, 
	   TypeId,
	   CreationDate,
	   OnlyDisplay
  FROM Item
 WHERE Price = IFNULL(@Price, Price) AND
       CostPrice = IFNULL(@CostPrice, CostPrice); 


