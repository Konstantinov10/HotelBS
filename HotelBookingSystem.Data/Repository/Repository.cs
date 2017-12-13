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
        public IEnumerable<ReservationInfo> ReservationInfos
        {
            get
            {
                return context.ReservationInfos.ToList();
            }

        }

       

        public void AddReservationInfo(ReservationInfo reservationInfo)
        {

            context.ReservationInfos.Add(reservationInfo);
            context.SaveChanges();

        }

       


    }
}

