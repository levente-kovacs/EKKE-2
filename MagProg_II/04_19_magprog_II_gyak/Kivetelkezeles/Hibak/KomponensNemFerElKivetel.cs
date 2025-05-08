using Kivetelkezeles.comonents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetelkezeles.Hibak
{
    internal class KomponensNemFerElKivetel : Exception
    {
        private IKomponens komponens;
        public IKomponens Komponens {  get { return komponens; } }

        public KomponensNemFerElKivetel(string message, IKomponens komponens) : base(message)
        {
            this.komponens = komponens;
        }
    }
}
