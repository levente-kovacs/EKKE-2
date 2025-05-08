using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetelkezeles.comonents
{
    internal class Hajtomu : IKomponens
    {
        public int Teljesitmeny { get; set; }
        public bool Allapot { get; set; }
        
        private int toloero;

        public void Aktival()
        {
            Teljesitmeny = toloero;
            Allapot = true;
        }

        public void Deaktival()
        {
            Teljesitmeny = 0;
            Allapot = false;
        }

        public Hajtomu(int toloero)
        {
            this.toloero = toloero;
        }
    }
}
