using Laba.service.serviceImpl;
using Laba.utility;
using Laba.view;
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

namespace Laba
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private UserService userService;
        public Registration()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            Close();
            login.Show();
        }
        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.NameUser = LoginRegistrationTextBox.Text;
            user.Pasword = PasswordRegistrationTextBox.Text;
            if (!userService.isUserTrue(user))
            {
                user.Role = 1;

                if (userService.correctSave(user))
                {
                    user = userService.correctGetModel(user.NameUser);
                    LocalStorege.LocalUser = user;
                    Customer customer = new Customer();
                    customer.Show();
                    Close();
                   
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Server error");
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Username is already taken");
            }
        }
    }
}
