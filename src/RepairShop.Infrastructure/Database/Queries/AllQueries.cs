 
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

    }
}
