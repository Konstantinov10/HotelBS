using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Data
{
    public class CustomerRepository
    {
        private Context context = new Context();
        public IEnumerable<Customer> Customers
        {
            get
            {
                return context.Customers.ToList();
            }

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
    }
}
