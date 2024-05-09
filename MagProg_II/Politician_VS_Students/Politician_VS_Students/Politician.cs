using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Politician_VS_Students
{
    class Politician : Person
    {
        private List<string> autokRendszamai;

        public Politician(string name, byte age) : base(name, age)
        {
            autokRendszamai = new List<string>();
        }

        public void BuyCar(string numberPlate)
        {
            autokRendszamai.Add(numberPlate);
        }

        public override void GetDrunk(byte level)
        {
            if (autokRendszamai.Count > 0 && level >= 100)
            {
                int ranomdIndex = rnd.Next(autokRendszamai.Count);
                autokRendszamai.RemoveAt(ranomdIndex);
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Age}) cars: {string.Join(", ", autokRendszamai)}";

            //string cars = "";
            //for (int i = 0; i < autokRendszamai.Count; i++)
            //{
            //    if (i == autokRendszamai.Count-1)
            //        cars += $"{autokRendszamai[i]}";
            //    else
            //        cars += $"{autokRendszamai[i]}, ";

            //}
            //return firstPart + cars;
        }
    }
}
