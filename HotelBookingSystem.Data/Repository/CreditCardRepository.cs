using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Data
{
    public class CreditCardRepository
    {
        private Context context = new Context();
        public IEnumerable<CreditCard> CreditCards
        {
            get
            {
                return context.CreditCards.ToList();
            }

        }



        public void AddCreditCard(CreditCard creditCard)
        {

            context.CreditCards.Add(creditCard);
            context.SaveChanges();

        }
    }
}
