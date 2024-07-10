UPDATE Document 
   SET Active = IFNULL(@Active, Active),
       TypeId = IFNULL(@TypeId, TypeId)
 WHERE Id = @Id