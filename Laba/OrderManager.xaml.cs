using Laba.Models;
using Laba.service.serviceImpl;
using Laba.view;
using System.Collections.Generic;
using System.Windows;

namespace Laba
{
    /// <summary>
    /// Interaction logic for OrderManager.xaml
    /// </summary>
    public partial class OrderManager : Window
    {
        private OrderService orderService;

        private List<Order> orders = new List<Order>();
        public OrderManager()
        {
            InitializeComponent();
            orderService = new OrderService();
            orders = orderService.correctAllList();
            foreach (Order o in orders)
            {
                List.Items.Add(o);
            }
        }

        private void refresh()
        {
            orders = orderService.correctAllList();
            List.Items.Refresh();
            List.Items.Clear();
            foreach (Order o in orders)
            {
                List.Items.Add(o);
            }
            List.Items.Refresh();
        }

        private void StorageButton_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }

        private void Update_button_Click(object sender, RoutedEventArgs e)
        {
            orderService.createRecord();
        }

        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            refresh();
        }
    }
}
