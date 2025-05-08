using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetelkezeles.comonents
{
    internal class Reaktor : IKomponens
    {
        public int Teljesitmeny { get; set; }
        public bool Allapot { get; set; }

        private int teljesitmeny;

        public void Aktival()
        {
            if (Allapot) throw new InvalidOperationException();
            if (teljesitmeny == 0) throw new NotSupportedException();
            Teljesitmeny = -teljesitmeny;
            Allapot = true;
        }

        public void Deaktival()
        {
            if (!Allapot) throw new InvalidOperationException();
            Teljesitmeny = 0;
            Allapot = false;
        }

        public Reaktor(int teljesitmeny)
        {
            this.teljesitmeny = teljesitmeny;
        }
    }
}
