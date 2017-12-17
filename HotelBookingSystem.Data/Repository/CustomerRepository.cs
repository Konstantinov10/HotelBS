using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Data
{
    public class PaymentHistory
    {
        public int cardId { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string CardDate { get; set; }
        public string CardHolder { get; set; }
        public double TotalSum { get; set; }
    }

    public class CustomerRepository
    {
        private Context context = new Context();
        public string CurrentLogin;
        public string CurrentName;

        public IEnumerable<Customer> Customers
        {
            get
            {
                return context.Customers.ToList();
            }

        }

        public IEnumerable<CreditCard> CreditCards
        {
            get
            {
                return context.CreditCards.ToList();
            }

        }


        public IEnumerable<Payment> Payments
        {
            get
            {
                return context.Payments.ToList();
            }

        }

        public IEnumerable<PaymentHistory> PaymentsHistory()
        {
            var payInfo = from card in CreditCards
                          join payment in Payments on card.ID equals payment.ID
                          where card.CardHolder == CurrentName
                          select new PaymentHistory ()
                          {

                              cardId = card.ID,
                              CardNumber = card.CardNumber,
                              CVV = card.CVV,
                              CardDate = card.Date,
                              CardHolder = card.CardHolder,
                              TotalSum = payment.TotalSum
                          };
            return payInfo.ToList<PaymentHistory>();
        }


        public void AddCustomer(Customer customer)
        {

            context.Customers.Add(customer);
            context.SaveChanges();

        }

        public bool CheckLogPass(string login,string password)
        {
            foreach (Customer c in context.Customers)
            {
                if (c.Login == login && c.Password == password)
                {
                    return true;
                }
            }
            return false;            
        }

        public string AccountFirstName (string login)
        {

            string fn="";
            foreach (Customer c in context.Customers)
            {
                if (c.Login == login)
                {
                    fn = c.FirstName;
                }
               

            }
            return fn;
        }

        public string AccountLastName(string login)
        {
            string ln;
            foreach (Customer c in context.Customers)
            {
                if (c.Login == login)
                {
                    return ln = c.LastName;
                }
                else
                {
                   

                }
                
            }
            return null;
        }

        public string AccountEmail(string login)
        {
            string em;
            foreach (Customer c in context.Customers)
            {
                if (c.Login == login)
                {
                    return em = c.Email;
                }
              
            }
            return em = null;
        }
    }
}
