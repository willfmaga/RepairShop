select Id, Name, Surname, BirthDate, Document,CreationDate , Active
  from Client
 where Name like concat('%', @Name,'%');;