using System.Windows;
using Npgsql;

namespace Delivery_client.DataBase
{
    internal class DeliveryDataBase
    {
        readonly string sqlConnectionString = "Server=localhost;Port=5432;DataBase=delivery_database;User Id=postgres;Password=2401;";
        internal NpgsqlConnection connection = new NpgsqlConnection();
        internal NpgsqlCommand command = new NpgsqlCommand();

        internal void SqlConnectionReader()
        {
            connection.ConnectionString = sqlConnectionString;
            command.Connection = connection;
            try
            {
                connection.Open();
            }
            catch(NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
