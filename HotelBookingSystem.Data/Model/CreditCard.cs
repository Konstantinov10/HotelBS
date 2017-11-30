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
        public int CardNumber { get; set; }
        public Customer FirstName { get; set; }
        public Customer LastName { get; set; }
        public int CVV { get; set; }
        public DateTime Date { get; set; }
        public Customer IDCustomer { get; set; }
        public Payment IDPayment { get; set; }
    }
}
