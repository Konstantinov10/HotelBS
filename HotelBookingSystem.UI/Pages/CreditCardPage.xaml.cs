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
        PaymentRepository _repositoryp;

        public CreditCardPage(Repository rs, CustomerRepository rp, PaymentRepository rppay)
        {
            InitializeComponent();
            _repositoryp = rppay;
            _reserv_rp = rs;
            _repository = rp;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxCardNum.Text.Length != 8 || string.IsNullOrWhiteSpace(textBoxCardNum.Text))
            {
                MessageBox.Show("Please, enter 8-digit card number!");
                textBoxCardNum.Clear();
                textBoxCardNum.Focus();
                return;
            }
            if (textBoxCardCVV.Text.Length != 3 || string.IsNullOrWhiteSpace(textBoxCardCVV.Text))
            {
                MessageBox.Show("Please, enter 3-digit card CVV!");
                textBoxCardCVV.Clear();
                textBoxCardCVV.Focus();
                return;
            }
            string s = textBoxCardDate.Text;
            string[] words = s.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            if (words[0].Length < 4 || string.IsNullOrWhiteSpace(textBoxCardDate.Text))
            {
                MessageBox.Show("Please, enter Date in the right format(XXXX.XX.XX)!");
                textBoxCardDate.Clear();
                textBoxCardDate.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxCardHolder.Text))
            {
                MessageBox.Show("Please, enter your name!");
                textBoxCardHolder.Focus();
                return;
            }
            else
            {

                CreditCard creditCard = new CreditCard();
                creditCard.CardNumber = textBoxCardNum.Text;
                creditCard.CardHolder = textBoxCardHolder.Text;
                creditCard.Date = textBoxCardDate.Text;
                creditCard.CVV = textBoxCardCVV.Text;

                _card_rp.AddCreditCard(creditCard);

                Payment p = new Payment();
                string st = _repositoryp.CurrentSum;
                string st2 = textBoxCardNum.Text;
                st2 = st2.Substring(0, 3);
                st = st.Substring(0, st.Length - 1);
                p.TotalSum = Convert.ToDouble(st);
                p.ID = Convert.ToInt32(st2);
                _repositoryp.AddPayment(p);
                NavigationService.Navigate(new BookingPage(_repository, _repositoryp));

            }
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
