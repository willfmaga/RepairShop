select Id, Name, Description, Address, Phone, Document , Active, CreationDate
  from Shop
 where Name like concat('%', @Name,'%');;