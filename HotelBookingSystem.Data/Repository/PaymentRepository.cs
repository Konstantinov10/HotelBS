using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Data
{
  public  class PaymentRepository
    {
        private Context context = new Context();
        public string CurrentSum;
        public IEnumerable<Payment> Payments
        {
            get
            {
                return context.Payments.ToList();
            }

        }



        public void AddPayment (Payment payment)
        {

            context.Payments.Add(payment);
            context.SaveChanges();

        }
    }
}
