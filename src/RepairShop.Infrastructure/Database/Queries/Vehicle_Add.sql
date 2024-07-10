INSERT INTO Vehicle(
            Plate,
            Name,
            Type, 
            Brand, 
            Model,
            Color,
            ManufactoringYear,
            Year, 
            Active)
     VALUES (@Name, 
             @Plate, 
             @Name, 
             @Type, 
             @Brand, 
             @Model,
             @Color, 
             @ManufactoringYear, 
             @Year, 
             @Active);


SELECT LAST_INSERT_ID();