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
        public string CurrentLogin;
        

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
