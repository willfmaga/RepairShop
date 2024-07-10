   UPDATE Vehicle
      SET   Plate = IFNULL(@Plate, Plate),
             Name = IFNULL(@Name, Name), 
           TypeId = IFNULL(@TypeId, TypeId),
          BrandId = IFNULL(@BrandId, BrandId),
            Model = IFNULL(@Model,Model),
           Active = IFNULL(@Active, Active),
             Year = IFNULL(@Year, Year),
ManufacturingYear = IFNULL(@ManufacturingYear, ManufacturingYear),
          ColorId = IFNULL(@ColorId, ColorId)
      WHERE  Id = @Id;


