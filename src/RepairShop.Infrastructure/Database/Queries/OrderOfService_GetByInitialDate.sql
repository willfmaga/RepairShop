SELECT Id,
       ShopId,
       ClientId,
       MechanicId, 
       VehicleId, 
       GeneralObservations,
       AmountItem,
       AmountService,
       Discount, 
       Total,
       InitialDate,
       DeliveryDate,
       CreationDate,
       Active
  FROM OrderOfService
 WHERE Convert(InitialDate, date) = Convert(@InitialDate,Date);