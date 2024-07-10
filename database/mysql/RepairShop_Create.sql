use RepairShop;

-- TYPE 
create table DocumentType(
Id smallint not null primary key, 
Description varchar(100));

     
create table PersonType(
Id smallint not null primary key, 
Description varchar(100));
      
       
create table VehicleType(
Id smallint not null primary key, 
Description varchar(100));

create table VehicleBrand(
Id smallint not null primary key, 
Description varchar(100));

create table VehicleColor(
Id smallint not null primary key, 
Description varchar(100));

create table ServiceType(
Id smallint not null primary key, 
Description varchar(100));

-- END TYPE 

create table Document(
Id bigint AUTO_INCREMENT primary key not null,
Type smallint not null, 
Value varchar(14) not null,
Active bit default 1 not null,
constraint FK_Document_DocumentType foreign key (Type) references DocumentType(Id));

create table Person(
Id bigint AUTO_INCREMENT primary key not null,
Name varchar(50) not null, 
Surname varchar(100) not null, 
BirthDate date not null, 
Type smallint not null,
DocumentId bigint not null,
Active bit default 1 not null,
CONSTRAINT FK_Person_Document FOREIGN KEY (DocumentId) REFERENCES Document(Id),
constraint FK_Person foreign key (Type) references PersonType(Id)
);

create table Shop(
Id bigint auto_increment primary key not null, 
Name varchar(100) not null, 
Description varchar(500) not null, 
Address varchar(500) not null, 
Phone varchar(13) not null,
DocumentId bigint not null,
CONSTRAINT FK_Shop_Document FOREIGN KEY (DocumentId) REFERENCES Document(Id),
Active bit default 1 not null
);

create table Vehicle(
Id bigint auto_increment primary key not null,
Plate varchar(7) not null,
Name varchar(50) not null,
Type smallint not null,
Brand smallint not null,
Model varchar(50) not null, 
Color smallint not null, 
ManufactoringYear smallint not null, 
Year smallint not null,
Active bit default 1 not null,
constraint FK_Vehicle_VehicleType foreign key (Type) references VehicleType(Id),
constraint FK_Vehicle_VehicleBrand foreign key (Brand) references VehicleBrand(Id),
constraint FK_Vehicle_VehicleColor foreign key (Color) references VehicleColor(Id)
);



 
