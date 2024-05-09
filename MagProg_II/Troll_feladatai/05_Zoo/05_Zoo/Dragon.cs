using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Zoo
{
    internal class Dragon : ICanCrawl, ICanFly
    {
        public void Crawl()
        {
            Console.WriteLine("A sárkány gyorsan mászik.");
        }

        public void Fly()
        {
            Console.WriteLine("A sárkány magasan repül.");
        }
    }
}
