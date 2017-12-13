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
        public List<Customer> Customers { get; set; }
        public List<Hotel> Hotels { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
