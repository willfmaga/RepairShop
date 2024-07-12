use RepairShop;

-- TYPE 
select * from  DocumentType;
select * from  PersonType;
select * from  VehicleType;
select * from  VehicleBrand;
select * from  VehicleColor;
select * from  ItemType;

-- END TYPE 

-- DOCUMENT
select * from Document d
inner join DocumentType t
on d.TypeId = t.Id;

truncate table Document; 
-- END DOCUMENT

-- PERSON 
select p.*, t.Description, d.Value, dt.Description from Person p 
inner join Document d on p.documentid = d.id 
inner join PersonType t on t.Id = p.TypeId
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

truncate table Vehicle;
-- END VEHICLE

-- ITEM
select * 
from Item i 
inner join ItemType t
on i.TypeId = t.Id;

truncate table Item;
-- END ITEM

-- ORDEROFSERVICE 
select * from OrderOfService o 
inner join Person p1 on p1.Id = o.ClientId
inner join Person p2 on p2.Id = o.MechanicId
inner join Vehicle v on v.Id = o.VehicleId
inner join Shop s on s.Id = o.ShopId;

truncate table OrderOfService;
-- END ORDEROFSERVICE






