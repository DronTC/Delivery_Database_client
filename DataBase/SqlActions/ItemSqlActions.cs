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
    class ItemSqlActions
    {
        static readonly DeliveryDataBase db = new DeliveryDataBase();
        internal static void AddItem(Item item)
        {
            db.SqlConnectionReader();

            db.command.CommandText = $"INSERT INTO del.Items (name, price, quantity) VALUES ('{item.Name}', '{item.Price}', '{item.Quantity}')";
            db.command.ExecuteNonQuery();

            db.connection.Close();
        }
        internal static Item? SelectItemById(int id)
        {
            int item_id, quantity;
            string name;
            double price;
            Item item;

            db.SqlConnectionReader();

            db.command.CommandText = $"SELECT * FROM del.Items WHERE item_id = {id}";

            NpgsqlDataReader reader = db.command.ExecuteReader();
            if (reader.Read())
            {
                item_id = reader.GetInt32(0);
                name = reader.GetString(1);
                price = reader.GetDouble(2);
                quantity = reader.GetInt32(3);
            }
            else
            {
                return null;
            }
            item = new Item(name, price, quantity, item_id);

            db.connection.Close();
            return item;
        }
        internal static DataTable SelectItems()
        {
            DataTable data;
            db.SqlConnectionReader();
            db.command.CommandText = $"SELECT * FROM del.Items";

            NpgsqlDataReader reader = db.command.ExecuteReader();

            data = new DataTable();
            data.Load(reader);

            db.connection.Close();
            return data;
        }
    }
}
