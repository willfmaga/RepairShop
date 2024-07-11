SELECT Plate,
	   Name, 
	   TypeId,
	   BrandId,
	   Model,
	   ColorId,
	   ManufacturingYear,
	   Year,
	   Active,
	   CreationDate
  FROM Vehicle 
 WHERE Id = @Id;