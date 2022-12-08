using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace CSharp_Practice.Codility
{
    public class FindConsectiveSeats
    {
        public int solution(int N, string S)
        {
            var hall = new Hall(N, 10);
            hall.ReserveSeats(S);

            Console.WriteLine(hall);

            int count = 0;
            foreach (var row in hall.Rows)
            {
                count += row.GetConsectiveSeats();
            }

            return count;
        }
    }
}
