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

create table ItemType(
Id smallint not null primary key, 
Description varchar(100));

-- END TYPE 

create table Document(
Id bigint AUTO_INCREMENT primary key not null,
TypeId smallint not null, 
Value varchar(14) not null,
Active bit default 1 not null,
CreationDate datetime not null,
constraint FK_Document_DocumentType foreign key (TypeId) references DocumentType(Id));

create table Person(
Id bigint AUTO_INCREMENT primary key not null,
Name varchar(50) not null, 
Surname varchar(100) not null, 
BirthDate date not null, 
TypeId smallint not null,
DocumentId bigint not null,
Active bit default 1 not null,
CreationDate datetime not null,
CONSTRAINT FK_Person_Document FOREIGN KEY (DocumentId) REFERENCES Document(Id),
constraint FK_Person foreign key (TypeId) references PersonType(Id)
);

create table Shop(
Id bigint auto_increment primary key not null, 
Name varchar(100) not null, 
Description varchar(500) not null, 
Address varchar(500) not null, 
Phone varchar(13) not null,
DocumentId bigint not null,
CreationDate datetime not null,
CONSTRAINT FK_Shop_Document FOREIGN KEY (DocumentId) REFERENCES Document(Id),
Active bit default 1 not null
);

create table Vehicle(
Id bigint auto_increment primary key not null,
Plate varchar(7) not null,
Name varchar(50) not null,
TypeId smallint not null,
BrandId smallint not null,
Model varchar(50) not null, 
ColorId smallint not null, 
ManufacturingYear smallint not null, 
Year smallint not null,
Active bit default 1 not null,
CreationDate datetime not null,
constraint FK_Vehicle_VehicleType foreign key (TypeId) references VehicleType(Id),
constraint FK_Vehicle_VehicleBrand foreign key (BrandId) references VehicleBrand(Id),
constraint FK_Vehicle_VehicleColor foreign key (ColorId) references VehicleColor(Id)
);


create table Item(
Id bigint auto_increment primary key not null,
Name varchar(250) not null, 
Price decimal(18,2) not null, 
CostPrice decimal(18,2) not null,
TypeId smallint not null,
CreationDate datetime not null,
OnlyDisplay bit not null,
constraint FK_Item_ItemType foreign key (TypeId) references ItemType(Id)
);

create table OrderOfService(
Id bigint auto_increment primary key not null, 
ShopId bigint not null, 
ClientId bigint not null, 
MechanicId bigint not null, 
VehicleId bigint not null, 
GeneralObservations varchar(2500) not null, 
AmountItem decimal(18,2) not null,
AmountService decimal(18,2) not null, 
Discount decimal(18,2) not null,
Total decimal(18,2) not null, 
InitialDate datetime not null, 
DeliveryDate datetime not null, 
CreationDate datetime not null,
Active bit default 1 not null,
constraint FK_Order_Shop foreign key (ShopId) references Shop(Id),
constraint FK_Order_Person_Client foreign key (ClientId) references Person(Id),
constraint FK_Order_Person_Mechanic foreign key (MechanicId) references Person(Id),
constraint FK_Order_Vehicle foreign key (VehicleId) references Vehicle(Id)
);


 
