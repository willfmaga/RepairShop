select Id, Name, Surname, BirthDate, TypeId, DocumentId 
  from Person
 where Name like concat('%', @Name,'%');;