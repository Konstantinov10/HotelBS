using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Data
{
   public class ReservationInfo
    {
        public int ID { get; set; }
        public Hotel HotelName { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public Room RoomType { get; set; }

    }
}
