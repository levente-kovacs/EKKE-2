using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetelkezeles.Hibak
{
    internal class NincsElegEnergiaKivetel : Exception
    {
        private int hianyMerteke;
        public int HianyMerteke { get { return hianyMerteke; } }

        public NincsElegEnergiaKivetel(int hianyMerteke) : base(string.Format($"Nincs elég teljesítmény, {hianyMerteke} MW hiányzik."))
        {
            this.hianyMerteke = hianyMerteke;
        }
    }
}
