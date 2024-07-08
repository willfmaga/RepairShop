select Id, Name, Surname, BirthDate, Type, DocumentId 
  from Person
 where Name like concat('%', @Name,'%');;