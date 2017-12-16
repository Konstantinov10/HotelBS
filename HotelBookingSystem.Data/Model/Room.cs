using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Data
{
    public class Room
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public List<Hotel> Hotels { get; set; }
    }
}
