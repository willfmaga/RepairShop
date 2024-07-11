select Id, TypeId, Value, Active, CreationDate
  from Document
 where Value = @Value
