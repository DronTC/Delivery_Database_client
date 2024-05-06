using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_client.DataBase.Models
{
    internal class Order
    {
        internal int? Id { get; private set; }
        internal int UserId { get; private set; }
        internal int CourierId { get; private set; }
        internal DateOnly OrderDate { get; private set; }
        internal TimeOnly OrderTime { get; private set; }
        internal string Address { get; private set; }
        internal Order(int userId, int courierId, DateOnly orderDate, TimeOnly orderTime, string address, int? id = null)
        {
            Id = id;
            UserId = userId;
            CourierId= courierId;
            OrderDate = orderDate;
            OrderTime = orderTime;
            Address = address;
        }
    }
}
