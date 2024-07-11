select Id, Name, Surname, BirthDate, TypeId, DocumentId,CreationDate , Active
  from Person
 where Name like concat('%', @Name,'%');;