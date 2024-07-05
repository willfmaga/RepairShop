use RepairShop;

drop table Document;

create table Document(
Id bigint AUTO_INCREMENT primary key not null,
Type smallint not null, 
Value varchar(14) not null,
Active bit default(1));

drop table Person;

create table Person(
Id bigint AUTO_INCREMENT primary key not null,
Name varchar(50) not null, 
Surname varchar(100) not null, 
BirthDate date not null, 
Type smallint not null
);


 
