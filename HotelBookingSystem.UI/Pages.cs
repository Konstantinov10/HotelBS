using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.UI
{
    class Pages
    {
        private static MainPage _mainPage = new MainPage();


        public static MainPage MainPage
        {
            get
            {
                return _mainPage;
            }
        }

        private static BookingPage _bookingPage = new BookingPage();


        public static BookingPage BookingPage
        {
            get
            {
                return _bookingPage;
            }
        }

        private static CreditCardPage _creditCardPage = new CreditCardPage();


        public static CreditCardPage CreditCardPage
        {
            get
            {
                return _creditCardPage;
            }
        }

        private static RegistrationPage _registrationPage = new RegistrationPage();


        public static RegistrationPage RegistrationPage
        {
            get
            {
                return _registrationPage;
            }
        }


        private static AccountPage _accountPage = new AccountPage();


        public static AccountPage AccountPage
        {
            get
            {
                return _accountPage;
            }
        }
    }
}
