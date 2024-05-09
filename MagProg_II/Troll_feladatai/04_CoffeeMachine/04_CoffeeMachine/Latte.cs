using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CoffeeMachine
{
    internal class Latte : Coffee
    {
        protected override void GrindCoffee()
        {
            Console.WriteLine("A gép durvára őröl 30 gram kávét.");
        }

        protected override void AddMilk()
        {
            Console.WriteLine("A gép a pohárba tölt 100 ml meleg tejet.");
        }
    }
}
