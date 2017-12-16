using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Data
{
    public class HotelRepository
    {
        private Context context = new Context();
        public IEnumerable<Hotel> Hotels
        {
            get
            {
                return context.Hotels.ToList();
            }

        }

        public void ReduceRoom (Hotel hotels)
        {
          
        }

    }
}
