use RepairShop;

insert into DocumentType(Id, Description) 
values (1, 'CPF'),
	   (2, 'CNPJ'),
       (3, 'RG');
       
insert into PersonType(Id, Description) 
values (1, 'Client'),
       (2, 'Mechanic'),
       (3, 'Owner');
       
insert into VehicleType(Id, Description) 
values (1, 'Bike'),
       (2, 'Car'),
       (3, 'Truck');

insert into VehicleBrand(Id, Description) 
values (1, 'Honda'),
       (2, 'Harley Davidson');
       
insert into VehicleColor(Id, Description) 
values (1, 'Red'),
       (2, 'Green'),
       (3, 'Black'),
       (4, 'Blue'),
       (5, 'Yellow'),
       (6, 'White'),
       (7, 'Gray'),
       (8, 'Purple'),
       (9, 'Beige');

insert into ServiceType(Id, Description) 
values (1, 'Service'),
       (2, 'Parts');