   UPDATE Shop
      SET Name = IFNULL(@Name, Name), 
   Description = IFNULL(@Description, Description),
       Address = IFNULL(@Address, Address),
         Phone = IFNULL(@Phone,Phone),
	DocumentId = IFNULL(@DocumentId, DocumentId),
        Active = IFNULL(@Active, Active)
      WHERE Id = @Id;


