select Id, Name, Surname, BirthDate, Type, DocumentId 
  from Person
 where Surname like concat('%', @Surname,'%');