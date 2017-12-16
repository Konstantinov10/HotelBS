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
    /// Логика взаимодействия для CreditCardPage.xaml
    /// </summary>
    public partial class CreditCardPage : Page
    {
        CreditCardRepository _card_rp = new CreditCardRepository();
        Repository _reserv_rp;
        CustomerRepository _repository;

        public CreditCardPage(Repository rs, CustomerRepository rp)
        {
            InitializeComponent();
            _reserv_rp = rs;
            _repository = rp;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           CreditCard creditCard = new CreditCard();
            creditCard.CardNumber = textBoxCardNum.Text;
            creditCard.CardHolder = textBoxCardHolder.Text;
            creditCard.Date = textBoxCardDate.Text;
            creditCard.CVV = textBoxCardCVV.Text;

            _card_rp.AddCreditCard(creditCard);
           
            NavigationService.Navigate(new BookingPage(_repository));
            
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
