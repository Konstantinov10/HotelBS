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

    }
}
