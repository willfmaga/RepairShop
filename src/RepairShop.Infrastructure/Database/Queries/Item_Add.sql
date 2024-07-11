INSERT INTO Item(
			Name, 
			Price, 
			CostPrice, 
			TypeId,
			CreationDate,
			OnlyDisplay
			)
	VALUES (@Name, 
			@Price, 
			@CostPrice, 
			@TypeId,
			@CreationDate,
			@OnlyDisplay
			);


SELECT LAST_INSERT_ID();