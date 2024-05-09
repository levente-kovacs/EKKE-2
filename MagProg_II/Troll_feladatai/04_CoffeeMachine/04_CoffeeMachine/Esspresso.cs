using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CoffeeMachine
{
    internal class Esspresso : Coffee
    {
        protected override void GrindCoffee()
        {
            Console.WriteLine("A gép finomra őröl 40 gram kávét.");
        }
    }
}
