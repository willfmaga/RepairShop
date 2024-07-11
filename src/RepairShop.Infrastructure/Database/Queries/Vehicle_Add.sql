INSERT INTO Vehicle(
            Plate,
            Name,
            TypeId, 
            BrandId, 
            Model,
            ColorId,
            ManufacturingYear,
            Year, 
            Active,
            CreationDate
            )
     VALUES ( 
             @Plate, 
             @Name, 
             @TypeId, 
             @BrandId, 
             @Model,
             @ColorId, 
             @ManufacturingYear, 
             @Year, 
             @Active,
             @CreationDate
             );


SELECT LAST_INSERT_ID();