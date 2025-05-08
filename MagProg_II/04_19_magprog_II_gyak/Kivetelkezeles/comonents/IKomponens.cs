using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetelkezeles.comonents
{
    internal interface IKomponens
    {
        int Teljesitmeny { get; set; }
        bool Allapot { get; set; }

        void Aktival();
        void Deaktival();
    }
}
