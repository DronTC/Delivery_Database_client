namespace Delivery_client.DataBase.Models
{
    internal class User
    {
        internal int? Id { get; private set; }
        internal string Name { get; private set; }
        internal string Surname { get; private set; }
        internal string? Patronymic { get; private set; }
        internal string Email { get; private set; }
        internal string PhoneNumber { get; private set; }
        internal User(string name, string surName, 
            string email, string phoneNumber, string? patronymic = null, int? id = null)
        {
            Id = id;
            Name = name;
            Surname = surName;
            Patronymic = patronymic;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
