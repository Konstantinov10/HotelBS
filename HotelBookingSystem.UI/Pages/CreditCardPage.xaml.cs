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
        CreditCardRepository _repository = new CreditCardRepository();
        public CreditCardPage()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           CreditCard creditCard = new CreditCard();
            creditCard.CardNumber = textBoxCardNum.Text;
            creditCard.CardHolder = textBoxCardHolder.Text;
            creditCard.Date = textBoxCardDate.Text;
            creditCard.CVV = textBoxCardCVV.Text;

            _repository.AddCreditCard(creditCard);
        }
    }
}
