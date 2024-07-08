UPDATE Document 
   SET Active = IFNULL(@Active, Active),
         Type = IFNULL(@Type, Type)
 WHERE Id = @Id