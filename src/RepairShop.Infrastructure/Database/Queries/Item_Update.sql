UPDATE Item
   SET Name = IFNULL(@Name, Name), 
	   Price = IFNULL(@Price, Price), 
	   CostPrice = IFNULL(@CostPrice, CostPrice), 
	   TypeId = IFNULL(@TypeId, TypeId),
	   OnlyDisplay = IFNULL(@OnlyDisplay, OnlyDisplay)
 WHERE Id = @Id;


SELECT LAST_INSERT_ID();