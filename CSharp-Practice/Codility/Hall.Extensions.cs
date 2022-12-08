using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Practice.Codility
{
    public static class HallExtensions
    {
        public static void ReserveSeats(this Hall hall, string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                var seats = s.Split(' ').Select(x => Helper.GetSeat(x)).ToList();
                foreach (var seat in seats)
                {
                    hall.ReserveSeat(seat.RowNumber, seat.Label);
                }
            }
        }
    }
}
