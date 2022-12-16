using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Practice.Turing
{
    public class SampleQuestion
    {
        public SampleQuestion()
        {

        }

        public int Solution(string[] ops)
        {
            var stack = new Stack<int>();
            foreach (var operand in ops)
            {
                switch (operand)
                {
                    case "C":
                        stack.Pop();
                        break;
                    case "D":
                        stack.Push(stack.Peek() * 2);
                        break;
                    case "+":
                        stack.Push(stack.Pop() + stack.Pop());
                        break;
                    default:
                        stack.Push(int.Parse(operand));
                        break;
                }
            }
            
            return stack.Sum();
        }
    }
}
