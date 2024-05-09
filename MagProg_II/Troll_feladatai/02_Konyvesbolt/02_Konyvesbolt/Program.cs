using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Konyvesbolt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Konyvesbolt bolt = new Konyvesbolt();

            foreach (Konyv konyv in bolt.Konyvek)
            {
                Console.WriteLine(konyv);
            }

            bolt.AddKonyv("Dan Simmons", "Endymion", 3700, Mufaj.SciFi);

            Console.ReadLine();
        }
    }
}
