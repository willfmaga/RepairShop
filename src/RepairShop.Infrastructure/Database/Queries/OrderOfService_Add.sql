INSERT INTO OrderOfService(
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
            CreationDate
            )
     VALUES (@ShopId,
            @ClientId,
            @MechanicId, 
            @VehicleId, 
            @GeneralObservations,
            @AmountItem,
            @AmountService,
            @Discount, 
            @Total,
            @InitialDate,
            @DeliveryDate,
            @CreationDate
             );


SELECT LAST_INSERT_ID();