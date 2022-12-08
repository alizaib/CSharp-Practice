using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Practice.HackerRank
{
    public class MinMaxSum
    {
        public MinMaxSum()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            Solution(list);
        }

        public void Solution(List<int> arr)
        {

            long sum = arr.Sum();

            long minSum = sum - arr.Max();
            long maxSum = sum - arr.Min();

            Console.WriteLine(minSum + " " + maxSum);
        }
    }
}
