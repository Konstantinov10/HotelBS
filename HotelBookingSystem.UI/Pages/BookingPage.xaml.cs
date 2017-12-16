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
        private Repository _reserv_repo = new Repository();
        private CustomerRepository _repository;

        public BookingPage(CustomerRepository rp)
        {
            InitializeComponent();
            _repository = rp;
            RefreshListBox();
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

            _reserv_repo.AddReservationInfo(resinfo);

            NavigationService.Navigate(new CreditCardPage(_reserv_repo, _repository));

            RefreshListBox();
            textBoxSum.Visibility = Visibility.Hidden;
            comboBoxRooms.IsEnabled = false;

        }       

        private void Button_Click(object sender,RoutedEventArgs e)
        {
            RefreshListBox();
            buttonDateApproved.IsEnabled = true;

            var button = sender as Button;
            int stars;
            int.TryParse(button.Uid, out stars);
            textBoxSum.Text = stars.ToString();
            listBoxBooking.Items.Add(button.Tag.ToString());
          

        }
        

        private void buttonDateApproved_Click(object sender, RoutedEventArgs e)
        {

            string[] spp = new string[listBoxBooking.Items.Count];
            for (int i = 0; i < spp.Length; i++)
                spp[i] = listBoxBooking.Items[i].ToString();

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


            if (dt2.Ticks < dt1.Ticks)
            {
                datePickerCheckin.Text = null;
                datePickerCheckout.Text = null;
                MessageBox.Show("Incorrect Date!");
            }
            else
            {
                if (spp.Length<1)
                {
                    datePickerCheckin.Text = null;
                    datePickerCheckout.Text = null;
                    MessageBox.Show("Please choose the Hotel!");
                  
                }
                else
                {
                    if (listBoxBooking.Items != null)
                    {
                        comboBoxRooms.IsEnabled = true;
                        buttonApproveAll.IsEnabled = true;
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
                    }
                  
                }
              
            }

           
            
           
           

          

            datePickerCheckin.Text=null;
            datePickerCheckout.Text = null;

            
            
        }

        private void Room_Selected(object sender,RoutedEventArgs e)
        {

            if (textBoxSum.Text != null)
            {
                var room = sender as ComboBoxItem;
                int price;
                int.TryParse(room.Uid, out price);
                long p = Convert.ToInt64(textBoxSum.Text) * price;
                textBoxSum.Text = p.ToString() + "$";
                listBoxBooking.Items.Add(room.Tag.ToString());
            }
           

        }      

       private void Button_MouseEnter(object sender,RoutedEventArgs e)
        {
            var button = sender as Button;
            button.FontSize = 14;
        }

        private void Button_MouseLeave(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            button.FontSize = 12;
        }

        private void buttonAccount_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AccountPage(_repository));
        }

        private void buttonApproveAll_Click(object sender, RoutedEventArgs e)
        {
            string[] spp = new string[listBoxBooking.Items.Count];
            for (int i = 0; i < spp.Length; i++)
                spp[i] = listBoxBooking.Items[i].ToString();

            if (listBoxBooking.Items == null || spp.Length < 4)
            {
                MessageBox.Show("Please enter all information!");
            }
            else
            {
                textBoxSum.Visibility = Visibility.Visible;
                buttonPurchase.Visibility = Visibility.Visible;
            }
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            textBoxSum.Text = null;
            textBoxSum.Visibility = Visibility.Hidden;
            comboBoxRooms.IsEnabled = false;
            RefreshListBox();

        }

       
    }
}
    

