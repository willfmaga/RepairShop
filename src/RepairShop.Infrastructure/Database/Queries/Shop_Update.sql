   UPDATE Shop
      SET Name = IFNULL(@Name, Name), 
   Description = IFNULL(@Description, Description),
       Address = IFNULL(@Address, Address),
         Phone = IFNULL(@Phone,Phone),
        Active = IFNULL(@Active, Active)
      WHERE Document = @Document;


