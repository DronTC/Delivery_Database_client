using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_client.DataBase.Models
{
    internal class Item
    {
        internal int? Id { get; private set; }
        internal string Name { get; private set; }
        internal double Price { get; private set; }
        internal int Quantity { get; private set; }
        internal Item(string name, double price, int quantity, int? id = null)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
