select Id, Name, Surname, BirthDate, TypeId, DocumentId 
  from Person
 where Surname like concat('%', @Surname,'%');