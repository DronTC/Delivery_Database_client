using Delivery_client.DataBase.Models;
using Npgsql;
using System.Data;

namespace Delivery_client.DataBase.SqlActions
{
    internal static class UserSqlActions
    {
        static readonly DeliveryDataBase db = new DeliveryDataBase();
        internal static void AddUser(User user)
        {
            db.SqlConnectionReader();

            db.command.CommandText = $"INSERT INTO del.Users (name, surname, patronymic, email, phone_number) VALUES ('{user.Name}', '{user.Surname}', '{user.Patronymic}', '{user.Email}', '{user.PhoneNumber}')";
            db.command.ExecuteNonQuery();

            db.connection.Close();
        }
        internal static User? SelectUserById(int id)
        {
            int user_id;
            string name, surname, email, phoneNumber;
            string? patronymic;
            User user;

            db.SqlConnectionReader();

            db.command.CommandText = $"SELECT * FROM del.Users WHERE user_id = {id}";

            NpgsqlDataReader reader = db.command.ExecuteReader();
            if (reader.Read())
            {
                user_id = reader.GetInt32(0);
                name = reader.GetString(1);
                surname = reader.GetString(2);
                try
                {
                    patronymic = reader.GetString(3);
                }
                catch
                {
                    patronymic = "Отсутствует";
                }
                email = reader.GetString(4);
                phoneNumber = reader.GetString(5);
            }
            else
            {
                return null;
            }
            user = new User(name, surname, email, phoneNumber, patronymic, user_id);

            db.connection.Close();
            return user;
        }
        internal static DataTable SelectUsers()
        {
            DataTable data;
            db.SqlConnectionReader();
            db.command.CommandText = $"SELECT * FROM del.Users";

            NpgsqlDataReader reader = db.command.ExecuteReader();

            data = new DataTable();
            data.Load(reader);

            db.connection.Close();
            return data;
        }
    }
}
