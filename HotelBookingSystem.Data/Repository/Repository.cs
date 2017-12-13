using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Data
{
  public  class Repository
    {
        private Context context = new Context();
        public IEnumerable<Customer> Customers
        {
            get
            {
                return context.Customers.ToList();
            }

        }

        public void DeleteProduct(Customer costumer)
        {

            context.Customers.Remove(costumer);
            context.SaveChanges();

        }

        public void AddCostumer(Customer costumer)
        {

            context.Customers.Add(costumer);
            context.SaveChanges();

        }

        public void UpdateCostumer(Customer newCustomer)
        {
            foreach (Customer p in context.Customers)
            {
                if (p.ID == newCustomer.ID)
                {
                    p.LastName = newCustomer.LastName;
                    p.FirstName = newCustomer.FirstName;
                    p.Email = newCustomer.Email;

                }

            }

            context.SaveChanges();
        }


    }
}

