using Delivery_client.DataBase.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_client.DataBase.SqlActions
{
    class CourierSqlActions
    {
        static readonly DeliveryDataBase db = new DeliveryDataBase();
        internal static void AddCourier(Courier courier)
        {
            db.SqlConnectionReader();

            db.command.CommandText = $"INSERT INTO del.Couriers (name, surname, patronymic, phone_number) VALUES ('{courier.Name}', '{courier.Surname}', '{courier.Patronymic}', '{courier.PhoneNumber}')";
            db.command.ExecuteNonQuery();

            db.connection.Close();
        }
        internal static Courier? SelectCourierById(int id)
        {
            int courier_id;
            string name, surname, phoneNumber;
            string? patronymic;
            Courier courier;

            db.SqlConnectionReader();

            db.command.CommandText = $"SELECT * FROM del.Couriers WHERE courier_id = {id}";

            NpgsqlDataReader reader = db.command.ExecuteReader();
            if (reader.Read())
            {
                courier_id = reader.GetInt32(0);
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
                phoneNumber = reader.GetString(5);
            }
            else
            {
                return null;
            }
            courier = new Courier(name, surname, phoneNumber, patronymic, courier_id);

            db.connection.Close();
            return courier;
        }
        internal static DataTable SelectCouriers()
        {
            DataTable data;
            db.SqlConnectionReader();
            db.command.CommandText = $"SELECT * FROM del.Couriers";

            NpgsqlDataReader reader = db.command.ExecuteReader();

            data = new DataTable();
            data.Load(reader);

            db.connection.Close();
            return data;
        }
    }
}
