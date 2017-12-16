using HotelBookingSystem.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelBookingSystem.UI
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        CustomerRepository _repository = new CustomerRepository();

        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void buttonRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text))
            {
                MessageBox.Show("Enter your first name");
                textBoxFirstName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxLastName.Text))
            {
                MessageBox.Show("Enter your last name");
                textBoxLastName.Focus();
                return;
            }         

            if (string.IsNullOrWhiteSpace(textBoxLogin.Text))
            {
                MessageBox.Show("Enter your login");
                textBoxLogin.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(passwordBoxPassword.Password))
            {
                MessageBox.Show("Enter your password");
                passwordBoxPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("Enter your email");
                textBoxEmail.Focus();
                return;
            }

            Customer customer = new Customer();
            customer.FirstName = textBoxFirstName.Text;
            customer.LastName = textBoxLastName.Text;
            customer.Login = textBoxLogin.Text;
            customer.Password = passwordBoxPassword.Password;
            customer.Email = textBoxEmail.Text;

            _repository.AddCustomer(customer);

            NavigationService.Navigate(Pages.MainPage);
        }

        private void Button_MouseEnter(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            button.FontSize = 14;
        }

        private void Button_MouseLeave(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            button.FontSize = 12;
        }

       
    }
}
