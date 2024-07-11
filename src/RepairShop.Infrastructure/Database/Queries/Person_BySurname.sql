select Id, Name, Surname, BirthDate, TypeId, DocumentId ,CreationDate, Active
  from Person
 where Surname like concat('%', @Surname,'%');