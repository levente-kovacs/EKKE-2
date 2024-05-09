using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Zoo
{
    internal class Albatross : ICanFly
    {
        public void Fly()
        {
            Console.WriteLine("Az albatrosz mereven tartva szárnyait vitorlázik.");
        }
    }
}
