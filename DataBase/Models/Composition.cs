using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_client.DataBase.Models
{
    internal class Composition
    {
        internal int ItemId { get; private set; }
        internal int OrderId { get; private set; }
        internal Composition(int itemId, int orderId)
        {
            ItemId = itemId;
            OrderId = orderId;
        }
    }
}
