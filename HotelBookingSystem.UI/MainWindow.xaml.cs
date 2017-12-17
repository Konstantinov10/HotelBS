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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static CustomerRepository repository = new CustomerRepository();
        private static PaymentRepository repositoryp = new PaymentRepository(); // че

        public MainWindow()
        {
            
            InitializeComponent();
            frameMain.Navigate(new MainPage(repository,repositoryp));
        }
    }
}
