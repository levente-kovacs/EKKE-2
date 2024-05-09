using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzallitoDLL
{
    internal interface IBiztositas
    {
        int Biztositas(int ertek);
        BiztositasTipus BiztositasTipus { get; set; }
    }
}
