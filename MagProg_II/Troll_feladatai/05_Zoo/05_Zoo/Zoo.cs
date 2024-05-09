using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Zoo
{
    internal class Zoo
    {
        public List<IAnimal> animals = new List<IAnimal>();

        public void AddAnimal(IAnimal animal)
        {
            animals.Add(animal);
        }
    }
}
