using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Practice.DestructorsDemo {

    public class Demo {
        public Demo() {
            Execute();

        }

        void Execute() {
            using (Parent p = new Child()) {

            }
        }
    }
    public class Parent : IDisposable {
        public Parent() {
            Console.WriteLine($"{nameof(Parent)} constructor");
        }
        ~Parent() {
            Console.WriteLine($"{nameof(Parent)} destructor");
        }

        public void Dispose() {
            Console.WriteLine($"{nameof(Parent)} disposed");            
        }
    }

    public class Child : Parent {
        public Child() {
            Console.WriteLine($"{nameof(Child)} constructor");
        }
        ~Child() {
            Console.WriteLine($"{nameof(Child)} destructor");
        }

        public new void Dispose() {
            Console.WriteLine($"{nameof(Child)} disposed");
            GC.SuppressFinalize(this);
        }
    }
}
