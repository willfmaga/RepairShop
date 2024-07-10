INSERT INTO Vehicle(
            Plate,
            Name,
            TypeId, 
            BrandId, 
            Model,
            ColorId,
            ManufacturingYear,
            Year, 
            Active)
     VALUES ( 
             @Plate, 
             @Name, 
             @TypeId, 
             @BrandId, 
             @Model,
             @ColorId, 
             @ManufacturingYear, 
             @Year, 
             @Active);


SELECT LAST_INSERT_ID();