using System;
using System.Data;
using System.Data.SqlClient;

namespace adodemo1
{
    class Program
 {
     static void Main(string[] args)
    {
        string connectionString =
        "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Wiprojuly2025;Integrated Security=True";

        
      using (SqlConnection connection = new SqlConnection(connectionString))
        {
         connection.Open();
         Console.WriteLine("Connection opened successfully.");

         connection.Close();
         Console.WriteLine("Connction closed.");
        }   
    }
  }
}
  
 