using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_client.DataBase.Models
{
    internal class Courier
    {
        internal int? Id { get; private set; }
        internal string Name { get; private set; }
        internal string Surname { get; private set; }
        internal string? Patronymic { get; private set; }
        internal string PhoneNumber { get; private set; }
        internal Courier(string name, string surName,
            string phoneNumber, string? patronymic = null, int? id = null)
        {
            Id = id;
            Name = name;
            Surname = surName;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
        }
    }
}
