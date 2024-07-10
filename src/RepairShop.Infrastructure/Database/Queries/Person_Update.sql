   UPDATE Person
      SET Name = IFNULL(@Name, Name), 
       Surname = IFNULL(@Surname, Surname),
     BirthDate = IFNULL(@BirthDate, BirthDate),
        Active = IFNULL(@Active,Active),
	    TypeId = IFNULL(@TypeId, TypeId)
      WHERE Id = @Id;


