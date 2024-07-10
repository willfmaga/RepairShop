 
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
