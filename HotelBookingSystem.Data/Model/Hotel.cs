using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Data
{
   public class Hotel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Stars { get; set; }
        public List<Room> Rooms { get; set; }
        public Payment IDPay { get; set; }
    }
}
