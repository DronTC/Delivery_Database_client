using Delivery_client.DataBase.Models;
using Delivery_client.DataBase.SqlActions;
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

namespace Delivery_client.Pages
{
    public partial class CouriersPage : Page
    {
        public CouriersPage()
        {
            InitializeComponent();
            DataTable dataTable = CourierSqlActions.SelectCouriers();
            MainDataGrid.ItemsSource = dataTable.AsDataView();
        }

        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            Courier courier;
            string? name = NameTextBox.Text;
            string? surname = SurnameTextBox.Text;
            string? patronymic = PatronymicTextBox.Text;
            string? phoneNumber = PhoneNumberTextBox.Text;


            if (name != null && surname != null && phoneNumber != null)
            {
                if (patronymic != null)
                    courier = new Courier(name, surname, phoneNumber, patronymic);
                else
                    courier = new Courier(name, surname, phoneNumber);
                CourierSqlActions.AddCourier(courier);
                DataTable dataTable = CourierSqlActions.SelectCouriers();
                MainDataGrid.ItemsSource = dataTable.AsDataView();
            }
            else
            {
                MessageBox.Show("Необходимо заполнить все обязательные поля");
            }
        }
    }
}
