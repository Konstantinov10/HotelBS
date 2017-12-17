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
    /// Логика взаимодействия для AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        CustomerRepository _repository;

        public AccountPage(CustomerRepository rp)
        {
            InitializeComponent();
            _repository = rp;
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {       
        }

        private void dataGridOrders_Loaded(object sender, RoutedEventArgs e)
        {
            textBlockFirstName.Text = _repository.AccountFirstName(_repository.CurrentLogin);
            textBlockLastName.Text = _repository.AccountLastName(_repository.CurrentLogin);
            textBlockEmail.Text = _repository.AccountEmail(_repository.CurrentLogin);
            dataGridOrders.ItemsSource = _repository.PaymentsHistory();
            _repository.CurrentName = textBlockFirstName.Text+" "+textBlockLastName.Text;
        }
    }
}
