using Laba.Models;
using Laba.service.serviceImpl;
using Laba.utility;
using System.Collections.Generic;
using System.Windows;

namespace Laba
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Window
    {
        private OrderService orderService;

        private List<Order> orders = new List<Order>();

        private ProductService productService;

        private List<Product> products = new List<Product>();
        public Customer()
        {
            InitializeComponent();
            orderService = new OrderService();
            productService = new ProductService();
            products = productService.correctAllList();
            orders = orderService.correctAllList();
            foreach (Order o in orders)
            {

                if (o.IdUser == LocalStorege.LocalUser.IdUser)
                {
                    List.Items.Add(o);
                }

            }
            foreach (Product p in products)
            {
                ProductList.Items.Add(p);
            }
        }
        private void refresh()
        {

            orders = orderService.correctAllList();
            products = productService.correctAllList();
            List.Items.Refresh();
            ProductList.Items.Clear();
            List.Items.Clear();
            foreach (Order o in orders)
            {
                if (o.IdUser == LocalStorege.LocalUser.IdUser)
                {
                    List.Items.Add(o);
                }

            }
            foreach (Product p in products)
            {
                ProductList.Items.Add(p);
            }
            List.Items.Refresh();
            ProductList.Items.Refresh();
        }
        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Product product = ProductList.SelectedItem as Product;
            Order order = new Order();
            order.IdUser = LocalStorege.LocalUser.IdUser;
            order.NameProduct = product.NameProduct;
            order.Price = product.Cost;
            order.LoginClient = LocalStorege.LocalUser.NameUser;
            if (orderService.correctSave(order))
            {

                refresh();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Server error");
            }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Order order = List.SelectedItem as Order;
            orderService.correctDelete(order);
            refresh();
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            Product product = ProductList.SelectedItem as Product;
            Order order = List.SelectedItem as Order;
            order.IdUser = LocalStorege.LocalUser.IdUser;
            order.NameProduct = product.NameProduct;
            order.Price = product.Cost;
            order.LoginClient = LocalStorege.LocalUser.NameUser;
            if (orderService.correctUpdate(order))
            {
                refresh();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Server error");
            }
        }
    }
}
