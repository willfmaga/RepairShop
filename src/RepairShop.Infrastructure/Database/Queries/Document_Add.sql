INSERT INTO Document
(Type, Value)
VALUES(       
       @Type, 
       @Value);


SELECT LAST_INSERT_ID();