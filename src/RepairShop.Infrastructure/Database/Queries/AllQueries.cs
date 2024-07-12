 
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace RepairShop.Infrastructure.Database.Queries
{
    public static class AllQueries 
    {
		private static string GetQuery([CallerMemberName]string propertyName = null)
        {
            var fileName = $"RepairShop.Infrastructure.Database.Queries.{propertyName}.sql";

            var stream = typeof(AllQueries).Assembly.GetManifestResourceStream(fileName);

            if (stream == null) throw new Exception($"The file {propertyName}.sql was not found in RepairShop.Infrastructure.Database.Queries");

            using (var sr = new StreamReader(stream))
            {
                return sr.ReadToEnd(); 
            }
        } 

		private static string _Document_Add;
        public static string Document_Add
        {
            get
            {
                if (_Document_Add is null)
                    _Document_Add = GetQuery();

                return _Document_Add;
            }
            set { _Document_Add = value; }
        }

		private static string _Document_ById;
        public static string Document_ById
        {
            get
            {
                if (_Document_ById is null)
                    _Document_ById = GetQuery();

                return _Document_ById;
            }
            set { _Document_ById = value; }
        }

		private static string _Document_ByValue;
        public static string Document_ByValue
        {
            get
            {
                if (_Document_ByValue is null)
                    _Document_ByValue = GetQuery();

                return _Document_ByValue;
            }
            set { _Document_ByValue = value; }
        }

		private static string _Document_Update;
        public static string Document_Update
        {
            get
            {
                if (_Document_Update is null)
                    _Document_Update = GetQuery();

                return _Document_Update;
            }
            set { _Document_Update = value; }
        }

		private static string _Item_Add;
        public static string Item_Add
        {
            get
            {
                if (_Item_Add is null)
                    _Item_Add = GetQuery();

                return _Item_Add;
            }
            set { _Item_Add = value; }
        }

		private static string _Item_GetAllForDisplay;
        public static string Item_GetAllForDisplay
        {
            get
            {
                if (_Item_GetAllForDisplay is null)
                    _Item_GetAllForDisplay = GetQuery();

                return _Item_GetAllForDisplay;
            }
            set { _Item_GetAllForDisplay = value; }
        }

		private static string _Item_GetById;
        public static string Item_GetById
        {
            get
            {
                if (_Item_GetById is null)
                    _Item_GetById = GetQuery();

                return _Item_GetById;
            }
            set { _Item_GetById = value; }
        }

		private static string _Item_GetByName;
        public static string Item_GetByName
        {
            get
            {
                if (_Item_GetByName is null)
                    _Item_GetByName = GetQuery();

                return _Item_GetByName;
            }
            set { _Item_GetByName = value; }
        }

		private static string _Item_GetByPriceAndCostPrice;
        public static string Item_GetByPriceAndCostPrice
        {
            get
            {
                if (_Item_GetByPriceAndCostPrice is null)
                    _Item_GetByPriceAndCostPrice = GetQuery();

                return _Item_GetByPriceAndCostPrice;
            }
            set { _Item_GetByPriceAndCostPrice = value; }
        }

		private static string _Item_GetByType;
        public static string Item_GetByType
        {
            get
            {
                if (_Item_GetByType is null)
                    _Item_GetByType = GetQuery();

                return _Item_GetByType;
            }
            set { _Item_GetByType = value; }
        }

		private static string _Item_Update;
        public static string Item_Update
        {
            get
            {
                if (_Item_Update is null)
                    _Item_Update = GetQuery();

                return _Item_Update;
            }
            set { _Item_Update = value; }
        }

		private static string _OrderOfService_Add;
        public static string OrderOfService_Add
        {
            get
            {
                if (_OrderOfService_Add is null)
                    _OrderOfService_Add = GetQuery();

                return _OrderOfService_Add;
            }
            set { _OrderOfService_Add = value; }
        }

		private static string _OrderOfService_GetByClientId;
        public static string OrderOfService_GetByClientId
        {
            get
            {
                if (_OrderOfService_GetByClientId is null)
                    _OrderOfService_GetByClientId = GetQuery();

                return _OrderOfService_GetByClientId;
            }
            set { _OrderOfService_GetByClientId = value; }
        }

		private static string _OrderOfService_GetByDeliveryDate;
        public static string OrderOfService_GetByDeliveryDate
        {
            get
            {
                if (_OrderOfService_GetByDeliveryDate is null)
                    _OrderOfService_GetByDeliveryDate = GetQuery();

                return _OrderOfService_GetByDeliveryDate;
            }
            set { _OrderOfService_GetByDeliveryDate = value; }
        }

		private static string _OrderOfService_GetById;
        public static string OrderOfService_GetById
        {
            get
            {
                if (_OrderOfService_GetById is null)
                    _OrderOfService_GetById = GetQuery();

                return _OrderOfService_GetById;
            }
            set { _OrderOfService_GetById = value; }
        }

		private static string _OrderOfService_GetByInitialDate;
        public static string OrderOfService_GetByInitialDate
        {
            get
            {
                if (_OrderOfService_GetByInitialDate is null)
                    _OrderOfService_GetByInitialDate = GetQuery();

                return _OrderOfService_GetByInitialDate;
            }
            set { _OrderOfService_GetByInitialDate = value; }
        }

		private static string _OrderOfService_GetByMechanicId;
        public static string OrderOfService_GetByMechanicId
        {
            get
            {
                if (_OrderOfService_GetByMechanicId is null)
                    _OrderOfService_GetByMechanicId = GetQuery();

                return _OrderOfService_GetByMechanicId;
            }
            set { _OrderOfService_GetByMechanicId = value; }
        }

		private static string _OrderOfService_GetByVehicleId;
        public static string OrderOfService_GetByVehicleId
        {
            get
            {
                if (_OrderOfService_GetByVehicleId is null)
                    _OrderOfService_GetByVehicleId = GetQuery();

                return _OrderOfService_GetByVehicleId;
            }
            set { _OrderOfService_GetByVehicleId = value; }
        }

		private static string _OrderOfService_Update;
        public static string OrderOfService_Update
        {
            get
            {
                if (_OrderOfService_Update is null)
                    _OrderOfService_Update = GetQuery();

                return _OrderOfService_Update;
            }
            set { _OrderOfService_Update = value; }
        }

		private static string _Person_Add;
        public static string Person_Add
        {
            get
            {
                if (_Person_Add is null)
                    _Person_Add = GetQuery();

                return _Person_Add;
            }
            set { _Person_Add = value; }
        }

		private static string _Person_ByBirthDate;
        public static string Person_ByBirthDate
        {
            get
            {
                if (_Person_ByBirthDate is null)
                    _Person_ByBirthDate = GetQuery();

                return _Person_ByBirthDate;
            }
            set { _Person_ByBirthDate = value; }
        }

		private static string _Person_ByDocument;
        public static string Person_ByDocument
        {
            get
            {
                if (_Person_ByDocument is null)
                    _Person_ByDocument = GetQuery();

                return _Person_ByDocument;
            }
            set { _Person_ByDocument = value; }
        }

		private static string _Person_ById;
        public static string Person_ById
        {
            get
            {
                if (_Person_ById is null)
                    _Person_ById = GetQuery();

                return _Person_ById;
            }
            set { _Person_ById = value; }
        }

		private static string _Person_ByName;
        public static string Person_ByName
        {
            get
            {
                if (_Person_ByName is null)
                    _Person_ByName = GetQuery();

                return _Person_ByName;
            }
            set { _Person_ByName = value; }
        }

		private static string _Person_BySurname;
        public static string Person_BySurname
        {
            get
            {
                if (_Person_BySurname is null)
                    _Person_BySurname = GetQuery();

                return _Person_BySurname;
            }
            set { _Person_BySurname = value; }
        }

		private static string _Person_Update;
        public static string Person_Update
        {
            get
            {
                if (_Person_Update is null)
                    _Person_Update = GetQuery();

                return _Person_Update;
            }
            set { _Person_Update = value; }
        }

		private static string _Shop_Add;
        public static string Shop_Add
        {
            get
            {
                if (_Shop_Add is null)
                    _Shop_Add = GetQuery();

                return _Shop_Add;
            }
            set { _Shop_Add = value; }
        }

		private static string _Shop_ByDocument;
        public static string Shop_ByDocument
        {
            get
            {
                if (_Shop_ByDocument is null)
                    _Shop_ByDocument = GetQuery();

                return _Shop_ByDocument;
            }
            set { _Shop_ByDocument = value; }
        }

		private static string _Shop_ById;
        public static string Shop_ById
        {
            get
            {
                if (_Shop_ById is null)
                    _Shop_ById = GetQuery();

                return _Shop_ById;
            }
            set { _Shop_ById = value; }
        }

		private static string _Shop_ByName;
        public static string Shop_ByName
        {
            get
            {
                if (_Shop_ByName is null)
                    _Shop_ByName = GetQuery();

                return _Shop_ByName;
            }
            set { _Shop_ByName = value; }
        }

		private static string _Shop_GetAll;
        public static string Shop_GetAll
        {
            get
            {
                if (_Shop_GetAll is null)
                    _Shop_GetAll = GetQuery();

                return _Shop_GetAll;
            }
            set { _Shop_GetAll = value; }
        }

		private static string _Shop_Update;
        public static string Shop_Update
        {
            get
            {
                if (_Shop_Update is null)
                    _Shop_Update = GetQuery();

                return _Shop_Update;
            }
            set { _Shop_Update = value; }
        }

		private static string _Vehicle_Add;
        public static string Vehicle_Add
        {
            get
            {
                if (_Vehicle_Add is null)
                    _Vehicle_Add = GetQuery();

                return _Vehicle_Add;
            }
            set { _Vehicle_Add = value; }
        }

		private static string _Vehicle_GetById;
        public static string Vehicle_GetById
        {
            get
            {
                if (_Vehicle_GetById is null)
                    _Vehicle_GetById = GetQuery();

                return _Vehicle_GetById;
            }
            set { _Vehicle_GetById = value; }
        }

		private static string _Vehicle_GetByPlate;
        public static string Vehicle_GetByPlate
        {
            get
            {
                if (_Vehicle_GetByPlate is null)
                    _Vehicle_GetByPlate = GetQuery();

                return _Vehicle_GetByPlate;
            }
            set { _Vehicle_GetByPlate = value; }
        }

		private static string _Vehicle_GetByTypeAndBrand;
        public static string Vehicle_GetByTypeAndBrand
        {
            get
            {
                if (_Vehicle_GetByTypeAndBrand is null)
                    _Vehicle_GetByTypeAndBrand = GetQuery();

                return _Vehicle_GetByTypeAndBrand;
            }
            set { _Vehicle_GetByTypeAndBrand = value; }
        }

		private static string _Vehicle_Update;
        public static string Vehicle_Update
        {
            get
            {
                if (_Vehicle_Update is null)
                    _Vehicle_Update = GetQuery();

                return _Vehicle_Update;
            }
            set { _Vehicle_Update = value; }
        }

    }
}
