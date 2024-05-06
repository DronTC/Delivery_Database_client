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
    class CompositionSqlActions
    {
        static readonly DeliveryDataBase db = new DeliveryDataBase();
        internal static void AddComposition(Composition composition)
        {
            db.SqlConnectionReader();

            db.command.CommandText = $"INSERT INTO del.Compositions (item_id, order_id) VALUES ('{composition.ItemId}', '{composition.OrderId}')";
            db.command.ExecuteNonQuery();

            db.connection.Close();
        }
    }
}
