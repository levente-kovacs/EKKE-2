using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Forma1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Idomero futam = new Idomero();

            Versenyzo alonso = new Versenyzo("Fernando Alonso", new Csapat("Aston Martin"), "01:35.173");
            Versenyzo sainz = new Versenyzo("Carlos Sainz", new Csapat("Ferrari"), "01:28:137");
            Versenyzo hammilton = new Versenyzo("Lewis Hammilton", new Csapat("Mercedes"), "01:33.254");

            futam.AddVersenyzo(alonso);
            futam.AddVersenyzo(sainz);
            futam.AddVersenyzo(hammilton);

            //if (alonso.CompareTo(hammilton) > 0)
            //    Console.WriteLine("Alonso gyorsabb volt.");
            //else if (alonso.CompareTo(hammilton) < 0)
            //    Console.WriteLine("Lewis volt gyorsabb.");
            //else Console.WriteLine("Ugyanolyan gyorsak voltak.");

            foreach (var versenyzo in futam)
            {
                Console.WriteLine(versenyzo);
            }

            Console.ReadLine();
        }
    }
}
