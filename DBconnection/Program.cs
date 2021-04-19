using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBconnection
{
    class Program
    {
        static void Main(string[] args)
        {
            //Connection string
            string ConnectionString = "Data Source = GK-S340\\SQLSERVER; Initial Catalog=Northwind; Integrated Security=true;";


            string queryString = "SELECT ProductID, UnitPrice, ProductName FROM Products WHERE UnitPrice > @pricePoint ORDER BY UnitPrice DESC";
            // SQL Cursor, Forward Only, Read ONLY
            int paramValue = 5;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                SqlParameter parameter = new SqlParameter("@pricePoint", paramValue);
                command.Parameters.Add(parameter);
                SqlDataReader reader = null;

                try
                {
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}", reader[0], reader[1], reader[2]);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (reader != null)
                    reader.Close();

                }


            }

            Console.ReadLine();
        }
    }
}
