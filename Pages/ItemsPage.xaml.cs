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
    /// <summary>
    /// Логика взаимодействия для ItemsPage.xaml
    /// </summary>
    public partial class ItemsPage : Page
    {
        public ItemsPage()
        {
            InitializeComponent();
            DataTable dataTable = ItemSqlActions.SelectItems();
            MainDataGrid.ItemsSource = dataTable.AsDataView();
        }

        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            Item item;
            string? name = NameTextBox.Text;
            double price;
            int quantity;
            try
            {
                price = Convert.ToDouble(PriceTextBox.Text);
                quantity = Convert.ToInt32(QuantityTextBox.Text);
            }
            catch
            {
                price = 0;
                quantity = 0;
            }


            if (name != null && price != 0 && quantity != 0)
            {
                item = new Item(name, price, quantity);

                ItemSqlActions.AddItem(item);
                DataTable dataTable = ItemSqlActions.SelectItems();
                MainDataGrid.ItemsSource = dataTable.AsDataView();
            }
            else
            {
                MessageBox.Show("Необходимо заполнить все обязательные поля");
            }
        }
    }
}
