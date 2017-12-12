namespace HotelBookingSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HotelBookingSystem.Data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HotelBookingSystem.Data.Context context)
        {
            Customer[] customers =
          {
                new Customer{ LastName = "Tsvaeva",FirstName = "Asya", Email = "atsvaeva98@gmail.com"},
                new Customer{ LastName = "Pupkin",FirstName = "Pter", Email = "pp@gmail.com"},
                new Customer{ LastName = "Tsoi",FirstName = "Lee", Email = "tsoi@gmail.com"}
            };

            Hotel[] hotels =
         {
                new Hotel{ Name = "Hilton Dubai",Location="Dubai",Stars=5},
               
            };

            Room[] rooms =
         {
                new Room{
                    Type = "Family",
                    Number =1,
                    Status = "Free",
                    Price = 50,
                   Customers = new List<Customer> { customers[0], customers[1] },
                },
               
            };

            context.Customers.AddOrUpdate(
               p => p.LastName,
               customers
               );
        }
    }
}
