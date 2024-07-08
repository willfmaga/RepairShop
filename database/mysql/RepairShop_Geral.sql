use RepairShop;

-- DOCUMENT
select * from Document;

truncate table Document; 
-- END DOCUMENT

-- PERSON 
select * from Person;
select * from Person p inner join Document d on p.documentid = d.id ;

truncate table Person;
-- END PERSON 
 
 
select Id, Name, Surname, BirthDate, Type, DocumentId 
  from Person
 where BirthDate = '1980-05-08';

-- SHOP 
select * from Shop ;

-- END SHOP 










