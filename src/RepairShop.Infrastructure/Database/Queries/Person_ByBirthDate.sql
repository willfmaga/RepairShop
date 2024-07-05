select Id, Name, Surname, BirthDate, Type, DocumentId 
  from Person
 where BirthDate = @BirthDate;