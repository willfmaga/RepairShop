SELECT Plate,
	   Name, 
	   TypeId,
	   BrandId,
	   Model,
	   ColorId,
	   ManufacturingYear,
	   Year,
	   Active
  FROM Vehicle 
 WHERE Plate = @Plate;