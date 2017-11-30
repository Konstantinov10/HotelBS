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
        public Customer IDCustomer { get; set; }
        public Hotel IDHotel { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
