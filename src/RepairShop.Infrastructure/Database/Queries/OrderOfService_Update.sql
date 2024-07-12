UPDATE OrderOfService
   SET ShopId               = IFNULL(@ShopId, ShopId),
       ClientId             = IFNULL(@ClientId, ClientId),
       MechanicId           = IFNULL(@MechanicId, MechanicId),
       VehicleId            = IFNULL(@VehicleId, VehicleId),
       GeneralObservations  = IFNULL(@GeneralObservations, GeneralObservations),
       AmountItem           = IFNULL(@AmountItem, AmountItem),
       AmountService        = IFNULL(@AmountService, AmountService),
       Discount             = IFNULL(@Discount, Discount),
       Total                = IFNULL(@Total, Total),
       InitialDate          = IFNULL(@InitialDate, InitialDate),
       DeliveryDate         = IFNULL(@DeliveryDate, DeliveryDate),
       Active               = IFNULL(@Active, Active)
 WHERE Id = @Id;