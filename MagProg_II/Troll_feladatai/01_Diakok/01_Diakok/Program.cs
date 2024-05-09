using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Diakok
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            Diak ede = new Diak("Troll Ede", "1987.05.04");
            Diak gergely = new Diak("Kovásznai Gergely", "1977.05.10", Gender.Ferfi, 3.54);

            Console.WriteLine(ede);
            Console.WriteLine(gergely);

            Console.ReadLine();
        }
    }
}