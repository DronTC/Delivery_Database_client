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
    class OrderSqlActions
    {
        static readonly DeliveryDataBase db = new DeliveryDataBase();
        internal static void AddOrder(Order order)
        {
            db.SqlConnectionReader();

            db.command.CommandText = $"INSERT INTO del.Orders (user_id, courier_id, order_date, order_time, address) VALUES ('{order.UserId}', '{order.CourierId}', '{order.OrderDate}', '{order.OrderTime}', '{order.Address}')";
            db.command.ExecuteNonQuery();

            db.connection.Close();
        }
        internal static Order? SelectOrderById(int id)
        {
            int order_id, user_id, courier_id;
            string address;
            DateOnly orderDate;
            TimeOnly orderTime;
            Order order;

            db.SqlConnectionReader();

            db.command.CommandText = $"SELECT * FROM del.Orders WHERE order_id = {id}";

            NpgsqlDataReader reader = db.command.ExecuteReader();
            if (reader.Read())
            {
                order_id = reader.GetInt32(0);
                user_id = reader.GetInt32(1);
                courier_id = reader.GetInt32(2);
                orderDate = DateOnly.Parse(reader.GetString(3));
                orderTime = TimeOnly.Parse(reader.GetString(4));
                address = reader.GetString(5);
            }
            else
            {
                return null;
            }
            order = new Order(user_id, courier_id, orderDate, orderTime, address);

            db.connection.Close();
            return order;
        }
        internal static DataTable SelectCouriers()
        {
            DataTable data;
            db.SqlConnectionReader();
            db.command.CommandText = $"SELECT * FROM del.Orders";

            NpgsqlDataReader reader = db.command.ExecuteReader();

            data = new DataTable();
            data.Load(reader);

            db.connection.Close();
            return data;
        }
    }
}
