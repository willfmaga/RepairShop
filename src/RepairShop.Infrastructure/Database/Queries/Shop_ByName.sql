select Id, Name, Description, Address, Phone, DocumentId , Active
  from Shop
 where Name like concat('%', @Name,'%');;