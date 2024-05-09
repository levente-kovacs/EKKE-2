using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Zoo
{
    internal class Lizard : ICanCrawl
    {
        public void Crawl()
        {
            Console.WriteLine("A kis gyík nagyon fürgén mászik.");
        }
    }
}
