using Laba.service.serviceImpl;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Laba.view;

namespace Laba
{
    /// <summary>
    /// Interaction logic for Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        private UserService userService;

        private List<User> users = new List<User>();
        public Manager()
        {
            userService = new UserService();
            InitializeComponent();
            users = userService.correctAllList();
            foreach (User u in users)
            {
                List.Items.Add(u);
            }
        }

        private void Refresh_button_Click(object sender, RoutedEventArgs e)
        {
            refresh();

        }

        private void refresh()
        {
            users = userService.correctAllList();
            List.Items.Refresh();
            List.Items.Clear();
            foreach (User u in users)
            {
                List.Items.Add(u);
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
                User user = List.SelectedItem as User;
                user.NameUser = LoginTextBox.Text;
                user.Pasword = PasswordTextBox.Text;

                if (!userService.isUserTrue(user))
                {
                    user.Role = 1;
                    if (userService.correctUpdate(user))
                    {
                        MessageBoxResult result = MessageBox.Show("Nikita error");
                        refresh();
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show("Art error");
                    }
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Server error");
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
                User user = new User();
                user.NameUser = LoginTextBox.Text;
                user.Pasword = PasswordTextBox.Text;

                if (!userService.isUserTrue(user))
                {
                    user.Role = 1;
                    if (userService.correctSave(user))
                    {
                        MessageBoxResult result = MessageBox.Show("NIkita error");
                        refresh();
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show("ART error");
                    }
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Server error");
                }

            }
        }

        private void Delete_button_Click(object sender, RoutedEventArgs e)
        {
            User user = List.SelectedItem as User;
            userService.correctDelete(user);
            refresh();
        }

        private void StorageButton_Click(object sender, RoutedEventArgs e)
        {
            AddProducts addProducts = new AddProducts();
            addProducts.Show();
            Close();
        }

        private void tologinButton_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }

        private void Order_button_Click(object sender, RoutedEventArgs e)
        {
            OrderManager order = new OrderManager();
            order.Show();
            Close();
        }
    }
}
