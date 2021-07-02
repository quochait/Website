using MySql.Data.MySqlClient;
using System;

namespace InsertDatabase
{
    public class CoffeeRepository : IDisposable
    {
        public MySqlConnection Connection;
        public CoffeeRepository(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}