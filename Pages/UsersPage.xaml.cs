using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Delivery_client.DataBase.Models;
using Delivery_client.DataBase.SqlActions;

namespace Delivery_client.Pages
{
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();
            DataTable dataTable = UserSqlActions.SelectUsers();
            MainDataGrid.ItemsSource = dataTable.AsDataView();
        }

        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            User user;
            string? name = NameTextBox.Text;
            string? surname = SurnameTextBox.Text;
            string? patronymic = PatronymicTextBox.Text;
            string? email = EmailTextBox.Text;
            string? phoneNumber = PhoneNumberTextBox.Text;


            if (name != null && surname != null && email != null && phoneNumber != null)
            {
                if (patronymic != null)
                    user = new User(name, surname, email, phoneNumber, patronymic);
                else
                    user = new User(name, surname, email, phoneNumber);
                UserSqlActions.AddUser(user);
                DataTable dataTable = UserSqlActions.SelectUsers();
                MainDataGrid.ItemsSource = dataTable.AsDataView();
            }
            else
            {
                MessageBox.Show("Необходимо заполнить все обязательные поля");
            }
        }
    }
}
