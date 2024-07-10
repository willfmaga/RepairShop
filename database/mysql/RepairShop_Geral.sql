use RepairShop;

-- TYPE 
select * from  DocumentType;
select * from  PersonType;
select * from  VehicleType;
select * from  VehicleBrand;
select * from  VehicleColor;
select * from  ServiceType;
-- END TYPE 

-- DOCUMENT
select * from Document d
inner join DocumentType t
on d.Type = t.Id;

truncate table Document; 
-- END DOCUMENT

-- PERSON 
select p.*, t.Description, d.Value, dt.Description from Person p 
inner join Document d on p.documentid = d.id 
inner join PersonType t on t.Id = p.Type
inner join DocumentType dt on dt.Id = p.DocumentId;

truncate table Person;
-- END PERSON 

-- SHOP 
select * from Shop p 
inner join Document d on d.Id = p.DocumentId 
inner join DocumentType dt on d.TypeId = dt.Id;

-- END SHOP 

-- VEHICLE 
select v.*, t.Description, b.Description, c.Description from Vehicle v
inner join VehicleType t on t.Id = v.TypeId 
inner join VehicleColor c on c.Id = v.ColorId
inner join VehicleBrand b on b.Id = v.BrandId
order by id ;

-- END VEHICLE









