using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Practice.Linq
{
    public class LinqDemo
    {
        public LinqDemo()
        {
            //LazyDemo();
            EagerDemo();
        }

        private void LazyDemo()
        {
            int[] numbers = { 5, 4, 1, 9 };
            int i = 0;
            var q = from n in numbers
                    select ++i;

            //had the above query executed by now, i would have a value 4 
            //and so in the the loop below i should have 4, but it is not the case
            //because the query executes lazily, running via an enumerator one by one
            //so the value of i changes with each iteration

            foreach (var v in q)
                Console.WriteLine($"v = {v}, i = {i}");

            /*
             * output:
             * v = 1, i = 1
             * v = 2, i = 2
             */
        }

        private void EagerDemo()
        {
            int[] numbers = { 5, 4, 1, 9 };
            int i = 0;
            var q = (from n in numbers
                    select ++i).ToList();            

            foreach (var v in q)
                Console.WriteLine($"v = {v}, i = {i}");

            /*
             * output:
             * v = 1, i = 4
             * v = 2, i = 4
             */
        }
    }
}
