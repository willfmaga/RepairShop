select Id, Name, Surname, BirthDate, TypeId, DocumentId 
  from Person
 where BirthDate = @BirthDate;