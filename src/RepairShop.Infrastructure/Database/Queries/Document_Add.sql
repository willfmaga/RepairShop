INSERT INTO Document
(TypeId, Value)
VALUES(       
       @TypeId, 
       @Value);


SELECT LAST_INSERT_ID();