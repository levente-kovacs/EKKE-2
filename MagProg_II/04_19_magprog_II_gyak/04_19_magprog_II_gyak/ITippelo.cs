using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_19_magprog_II_gyak
{
    internal interface ITippelo : IJatekos, ICloneable
    {
        void JatekIndul(int alsoHatar, int felsoHatar);

        int KovetkezoTipp();
    }
}
