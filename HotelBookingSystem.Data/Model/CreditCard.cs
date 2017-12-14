using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Data
{
    public class CreditCard
    {
        public int ID { get; set; }
        public string CardNumber { get; set; }
        public string CardHolder { get; set; }
        public string CVV { get; set; }
        public string Date { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
