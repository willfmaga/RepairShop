use RepairShop;

drop table Shop;
drop table Person;
drop table Document;

create table Document(
Id bigint AUTO_INCREMENT primary key not null,
Type smallint not null, 
Value varchar(14) not null,
Active bit default 1 not null );

create table Person(
Id bigint AUTO_INCREMENT primary key not null,
Name varchar(50) not null, 
Surname varchar(100) not null, 
BirthDate date not null, 
Type smallint not null,
DocumentId bigint not null,
Active bit default 1 not null,
CONSTRAINT FK_Person_Document FOREIGN KEY (DocumentId)
REFERENCES Document(Id)
);

create table Shop(
Id bigint auto_increment primary key not null, 
Name varchar(100) not null, 
Description varchar(500) not null, 
Address varchar(500) not null, 
Phone varchar(13) not null,
DocumentId bigint not null,
CONSTRAINT FK_Shop_Document FOREIGN KEY (DocumentId)
REFERENCES Document(Id),
Active bit default 1 not null
);


 
