using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CoffeeMachine
{
    internal abstract class Coffee
    {
        public Coffee()
        {
            HeatFilament();
            GrindCoffee();
            PourWater();
            AddMilk();
        }

        private void HeatFilament() { Console.WriteLine("Fűtőszál felmelegítése."); }
        protected abstract void GrindCoffee();
        private void PourWater() { Console.WriteLine("A gép átnyomja a vizet a kávén."); }
        protected virtual void AddMilk() { }
    }
}
