using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            zoo.AddAnimal(new Kolibri());
            zoo.AddAnimal(new Albatross());
            zoo.AddAnimal(new Komodo());
            zoo.AddAnimal(new Lizard());
            zoo.AddAnimal(new Dragon());

            foreach (IAnimal animal in zoo.animals)
            {
                if (animal is ICanFly)
                    ((ICanFly)animal).Fly();

                if (animal is ICanCrawl)
                    ((ICanCrawl)animal).Crawl();
            }

            Console.ReadLine();
        }
    }
}