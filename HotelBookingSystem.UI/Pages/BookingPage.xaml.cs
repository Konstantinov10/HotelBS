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
    /// Логика взаимодействия для BookingPage.xaml
    /// </summary>
    public partial class BookingPage : Page
    {
        Repository _repository = new Repository();
        public BookingPage()
        {
            InitializeComponent();

            
        }

        private void RefreshListBox()
        {
            listBoxBooking.Items.Clear();
        }

        private void buttonPurchase_Click(object sender, RoutedEventArgs e)
        {
          

            ReservationInfo resinfo = new ReservationInfo();

            string[] spp = new string[listBoxBooking.Items.Count];
            for (int i = 0; i < spp.Length; i++)
                spp[i] = listBoxBooking.Items[i].ToString();

            resinfo.HotelName = spp[0];
            resinfo.CheckIn = spp[1];
            resinfo.CheckOut = spp[2];
            resinfo.RoomType = spp[3];

            _repository.AddReservationInfo(resinfo);

            NavigationService.Navigate(Pages.CreditCardPage);

            RefreshListBox();

        }

        private void buttonHotel3_Click(object sender, RoutedEventArgs e)
        {
            RefreshListBox();

            listBoxBooking.Items.Add("Hilton Dubai");
            textBoxSum.Text = "4";

        }

        private void buttonHotel1_Click(object sender, RoutedEventArgs e)
        {
            RefreshListBox();

            listBoxBooking.Items.Add("Feduk Budapest");
            textBoxSum.Text = "2";

        }

        private void buttonHotel2_Click(object sender, RoutedEventArgs e)
        {
            RefreshListBox();

            listBoxBooking.Items.Add("Mariott Madrid");
            textBoxSum.Text = "3";

        }

        private void buttonDateApproved_Click(object sender, RoutedEventArgs e)
        {

            //string[] spp = new string[listBoxBooking.Items.Count];
            //for (int i = 0; i < spp.Length; i++)
            //    spp[i] = listBoxBooking.Items[i].ToString();

            //if(spp[1]!=null && spp[2]!=null)
            //{
            //    spp[1] = null;
            //    spp[2] = null;
            //    RefreshListBox();
            //}

            long time = 0;

            DateTime dt1 = new DateTime();
            DateTime dt2 = new DateTime();
           
            string st1 = datePickerCheckin.Text;
            string st2 = datePickerCheckout.Text;

            dt1 = Convert.ToDateTime(st1);
            dt2 = Convert.ToDateTime(st2);

            time = dt2.Ticks - dt1.Ticks;

            DateTime time2 = new DateTime(time);
            long countDays = time2.Day;

            listBoxBooking.Items.Add(st1);
            listBoxBooking.Items.Add(st2);

           
            if (textBoxSum.Text == "2")
            {
                textBoxSum.Text = (2 * countDays).ToString(); 
                
            }
            if (textBoxSum.Text == "3")
            {
                textBoxSum.Text = (3 * countDays).ToString();

            }
            else
            {
                textBoxSum.Text = (4 * countDays).ToString();

            }

            datePickerCheckin.Text=null;
            datePickerCheckout.Text = null;
            
        }

        private void FamilyRoom_Selected(object sender, RoutedEventArgs e)
        {
            listBoxBooking.Items.Add("Family - 4 per");

            long p = Convert.ToInt64(textBoxSum.Text) * 50;
            textBoxSum.Text = p.ToString();

        }

        private void SingleRoom_Selected(object sender, RoutedEventArgs e)
        {
            listBoxBooking.Items.Add("Single - 1 per");

            long p = Convert.ToInt64(textBoxSum.Text) * 20;
            textBoxSum.Text = p.ToString() + "$";
        }

        private void LuxRoom1_Selected(object sender, RoutedEventArgs e)
        {
            listBoxBooking.Items.Add("Lux - 1 per");

            long p = Convert.ToInt64(textBoxSum.Text) * 100;
            textBoxSum.Text = p.ToString() + "$";
        }

        private void LuxRoom2_Selected(object sender, RoutedEventArgs e)
        {
            listBoxBooking.Items.Add("Lux - 2 per");

            long p = Convert.ToInt64(textBoxSum.Text) * 200;
            textBoxSum.Text = p.ToString() + "$";
        }

        private void datePickerCheckin_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {          
        }
    }
}
    

