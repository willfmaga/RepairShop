select Id, Name, Description, Address, Phone, DocumentId , Active, CreationDate
  from Shop
 where Name like concat('%', @Name,'%');;