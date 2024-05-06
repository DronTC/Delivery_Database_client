using Delivery_client.DataBase.SqlActions;
using System.Windows;
using Delivery_client.DataBase.Models;
using Delivery_client.Pages;
using System.Windows.Controls;
using System.Data;

namespace Delivery_client
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UsersBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new UsersPage();
        }

        private void CouriersBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new CouriersPage();
        }

        private void ItemsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ItemsPage();
        }

        private void OrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new OrdersPage();
        }
    }
}