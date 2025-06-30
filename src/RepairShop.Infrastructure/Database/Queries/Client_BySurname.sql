select Id, Name, Surname, BirthDate, Document ,CreationDate, Active
  from Client
 where Surname like concat('%', @Surname,'%');