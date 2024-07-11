INSERT INTO Document(
            TypeId, 
            Value,
            CreationDate)
     VALUES(       
       @TypeId, 
       @Value,
       @CreationDate
       );


SELECT LAST_INSERT_ID();