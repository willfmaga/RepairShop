using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopTest
{
    public class UtilForTest
    {
        public static string connectionString = @"server=localhost;port=3306;database=RepairShop;user=root;password=root;";


        public static void TruncateTables()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            var command = string.Concat("SET FOREIGN_KEY_CHECKS = 0;",
                                        "truncate table OrderOfService;",
                                        "truncate table Item;",
                                        "truncate table Vehicle;",
                                        "truncate table Shop;",
                                        "truncate table Person;",
                                        "truncate table Document;",
                                        "SET FOREIGN_KEY_CHECKS = 1;");

            using (MySqlCommand cmd = new MySqlCommand(command, connection))
            {
                connection.Open();

                cmd.ExecuteNonQuery();
            }
        }


    }
}
