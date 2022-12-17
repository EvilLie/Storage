using Laba.service.serviceImpl;
using Laba.utility;
using System;
using System.Windows;

namespace Laba.view
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        private UserService userService;

        public Login()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
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
                if (userService.isUserTrueWithPassword(user))
                {
                    user = userService.correctGetModel(user.NameUser);
                    LocalStorege.LocalUser = user;
                    if (user.Role == 0)
                    {
                        Manager manager = new Manager();
                        manager.Show();
                        Close();
                   
                    }
                    else
                    {
                        Customer customer = new Customer();
                        customer.Show();
                        Close();
                        
                    }
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Password or login is incorrect");
                }
            }


        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            Close();
        }
    }
}
