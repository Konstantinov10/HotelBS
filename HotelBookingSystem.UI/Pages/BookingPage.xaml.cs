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

        private void buttonPurchase_Click(object sender, RoutedEventArgs e)
        {
            ReservationInfo resinfo = new ReservationInfo();

            string[] spp = new string[listBoxBooking.Items.Count];
            for (int i = 0; i < spp.Length; i++)
                spp[i] = listBoxBooking.Items[i].ToString();

            resinfo.HotelName.Name = spp[0];
            resinfo.CheckIn = spp[1];
            resinfo.CheckOut = spp[2];
            resinfo.RoomType.Type = spp[3];

            _repository.AddReservationInfo(resinfo);
        }

        private void buttonHotel3_Click(object sender, RoutedEventArgs e)
        {
         
                listBoxBooking.Items.Add("Hilton Dubai");

        }

        private void buttonHotel1_Click(object sender, RoutedEventArgs e)
        {
            listBoxBooking.Items.Add("Feduk Budapest");
        }

        private void buttonHotel2_Click(object sender, RoutedEventArgs e)
        {
            listBoxBooking.Items.Add("Mariott Madrid");
        }

        private void buttonDateApproved_Click(object sender, RoutedEventArgs e)
        {
           
            string st = datePickerCheckin.Text;
            string st2 = datePickerCheckout.Text;
            listBoxBooking.Items.Add(st);
            listBoxBooking.Items.Add(st2);

        }

        private void FamilyRoom_Selected(object sender, RoutedEventArgs e)
        {
            listBoxBooking.Items.Add("Family - 4 per");
        }

        private void SingleRoom_Selected(object sender, RoutedEventArgs e)
        {
            listBoxBooking.Items.Add("Single - 1 per");
        }

        private void LuxRoom1_Selected(object sender, RoutedEventArgs e)
        {
            listBoxBooking.Items.Add("Lux - 1 per");
        }

        private void LuxRoom2_Selected(object sender, RoutedEventArgs e)
        {
            listBoxBooking.Items.Add("Lux - 2 per");
        }
    }
        }
    

