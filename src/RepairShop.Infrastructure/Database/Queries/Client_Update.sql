   UPDATE Client
      SET Name = IFNULL(@Name, Name), 
       Surname = IFNULL(@Surname, Surname),
     BirthDate = IFNULL(@BirthDate, BirthDate),
        Active = IFNULL(@Active,Active)
      WHERE Document = @Document;


