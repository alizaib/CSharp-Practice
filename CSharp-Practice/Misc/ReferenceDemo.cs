using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Practice.Misc {
    public class ReferenceDemo {
        public ReferenceDemo() {            
            Person p = new Person { Name = "Ali" };

            PlayWithObject(p);
            Console.WriteLine(p.Name);

            PlayWithRef(ref p);
            Console.WriteLine(p.Name);
        }

        public void PlayWithObject(Person p) {
            p.Name = "Changed";
        }

        public void CantWithObject(IPerson p) {
            // Now it can't change it
            //p.Name = "Changed";
        }

        public void PlayWithRef(ref Person p) {
            p = new Person();
            p.Name = "With Different Name";
        }

    }

    public interface IPerson {
        string Name { get; }
    }

    public class Person : IPerson {
        public string Name { get; set; }
    }
}
