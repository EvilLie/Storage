using Laba.Models;
using Laba.service.serviceImpl;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Laba
{
    /// <summary>
    /// Interaction logic for AddProducts.xaml
    /// </summary>
    public partial class AddProducts : Window
    {
        private ProductService productService;

        private List<Product> products = new List<Product>();
        public AddProducts()
        {
            InitializeComponent();
            productService = new ProductService();
            products = productService.correctAllList();
            foreach (Product p in products)
            {
                List.Items.Add(p);
            }
        }

        private void Refresh_button_Click(object sender, RoutedEventArgs e)
        {
            refresh();
        }
        private void refresh()
        {
            products = productService.correctAllList();
            List.Items.Refresh();
            List.Items.Clear();
            foreach (Product p in products)
            {
                List.Items.Add(p);
            }
            List.Items.Refresh();
        }

        private void Update_button_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(LoginTextBox.Text) || (String.IsNullOrEmpty(PasswordTextBox.Text)))
            {
                MessageBoxResult result = MessageBox.Show("Username/password is empty");
            }
            else
            {
                Product product = List.SelectedItem as Product;
                product.NameProduct = LoginTextBox.Text;
                product.Cost = Convert.ToDouble(PasswordTextBox.Text);
                product.IdUser = 1;

                if (productService.correctUpdate(product))
                {
                    refresh();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Error");
                }
            }
        }

        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(LoginTextBox.Text) || (String.IsNullOrEmpty(PasswordTextBox.Text)))
            {
                MessageBoxResult result = MessageBox.Show("Username/password is empty");
            }
            else
            {
                Product product = new Product();
                product.NameProduct = LoginTextBox.Text;
                product.Cost = Convert.ToDouble(PasswordTextBox.Text);
                product.IdUser = 1;

                if (productService.correctSave(product))
                {
                    refresh();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Error");
                }
            }
        }

        private void Delete_button_Click(object sender, RoutedEventArgs e)
        {
            Product product = List.SelectedItem as Product;
            productService.correctDelete(product);
            refresh();
        }

        private void StorageButton_Click(object sender, RoutedEventArgs e)
        {
            Manager manager = new Manager();
            manager.Show();
            Close();
        }
    }
}
