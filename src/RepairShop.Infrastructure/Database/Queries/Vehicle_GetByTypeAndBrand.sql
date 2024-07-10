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
 WHERE TypeId = IFNULL(@TypeId, TypeId) AND
	  BrandId = IFNULL(@BrandId, BrandId);