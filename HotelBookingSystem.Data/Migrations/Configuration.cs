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
                    Price=50,                 
                    NumberOfRooms=50,
                    },

                new Room{
                    Type = "Single",
                    Price = 20,
                    NumberOfRooms=50,
                    },

                new Room{
                    Type = "Lux",                                   
                    Price = 100,
                    NumberOfRooms=50,
                   }
            };

            //ReservationInfo[] reservationinfos =
            //    {
            //    new ReservationInfo
            //    {
                
            //     HotelName = {hotels[1]},
            //     CheckIn = new DateTime(2017,8,12),
            //     CheckOut = new DateTime(2017,9,12)
            //    },

            //      new ReservationInfo
            //    {
                 
            //     Hotels = new List<Hotel> {hotels[0] },
            //     CheckIn = new DateTime(2017,8,12),
            //     CheckOut = new DateTime(2017,9,12)
            //    },

            //        new ReservationInfo
            //    {
                 
            //     Hotels = new List<Hotel> {hotels[0] },
            //     CheckIn = new DateTime(2017,8,10),
            //     CheckOut = new DateTime(2017,9,10)
            //    },
            //};

            Payment[] payments =
           {
                new Payment { TotalSum = 300 },
                new Payment { TotalSum = 100 },
                new Payment { TotalSum = 50 }
            };

            //CreditCard[] creditcards =
            //{
            //    new CreditCard
            //    {
            //        CardNumber = 12345678,
            //        Customers = new List<Customer> { customers[0] },
            //        CVV = 123,
            //        Date = new DateTime(2021,10,12),
            //        Payments = new List<Payment> { payments[1] }
            //    },


            //     new CreditCard
            //    {
            //        CardNumber = 12345671,
            //        Customers = new List<Customer> { customers[2] },
            //        CVV = 123,
            //        Date = new DateTime(2020,10,12),
            //        Payments = new List<Payment> {payments[0] },
                    
            //    },
            //};

           

            context.Hotels.AddOrUpdate(
               p => p.Name,
               hotels
               );

            context.Customers.AddOrUpdate(
              p => p.LastName,
              customers
              );

            context.Rooms.AddOrUpdate(
              p => p.ID,
              rooms
              );

            //context.ReservationInfos.AddOrUpdate(
            //  p => p.ID,
            //  reservationinfos
            //  );

            context.Payments.AddOrUpdate(
            p => p.ID,
            payments
            );

            //context.CreditCards.AddOrUpdate(
            //p => p.CardNumber,
            //creditcards
            //);
        }
    }
}
