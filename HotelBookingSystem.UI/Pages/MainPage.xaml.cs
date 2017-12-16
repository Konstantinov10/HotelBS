﻿using System;
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
using HotelBookingSystem.Data;

namespace HotelBookingSystem.UI
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        CustomerRepository _repository;

        public MainPage(CustomerRepository rp)
        {
            InitializeComponent();
            _repository = rp;
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxLogin.Text))
            {
                MessageBox.Show("Enter your login");
                textBoxLogin.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(passwordBoxPassword.Password))
            {
                MessageBox.Show("Enter your password");
                passwordBoxPassword.Focus();
                return;
            }

            if (_repository.CheckLogPass(textBoxLogin.Text, passwordBoxPassword.Password))
            {
                _repository.CurrentLogin = textBoxLogin.Text;
                NavigationService.Navigate(new BookingPage(_repository));
            }
            else
            {
                MessageBox.Show("Incorrect login or password");
                textBoxLogin.Clear();
                passwordBoxPassword.Clear();
                textBoxLogin.Focus();
                return;
            }

        }

        private void buttonRegistration_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage(_repository));
            
        }

        private void Button_MouseEnter(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            button.FontSize = 14;
        }

        private void Button_MouseLeave(object sender,RoutedEventArgs e)
        {
            var button = sender as Button;
            button.FontSize = 12;
        }

      
    }
}
