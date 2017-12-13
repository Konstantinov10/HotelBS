﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Data
{
   public class ReservationInfo
    {
        public int ID { get; set; }
        public string HotelName { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public string RoomType { get; set; }

    }
}
