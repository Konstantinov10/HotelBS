﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Data
{
   public class Customer
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int ID { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
