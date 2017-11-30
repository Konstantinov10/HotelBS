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
        public int Number { get; set; }
        public string Status { get; set; }
        public double Price { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Hotel> Hotels { get; set; }
    }
}
