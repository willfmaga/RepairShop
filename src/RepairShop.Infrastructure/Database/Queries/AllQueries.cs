 
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

    }
}
