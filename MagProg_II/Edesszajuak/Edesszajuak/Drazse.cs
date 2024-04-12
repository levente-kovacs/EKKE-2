using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edesszajuak
{
    internal class Drazse : Edesseg
    {
        public Szin Szin { get; set; }

        public Drazse(string nev, float cukorTartalom, float tomeg, Szin szin) : base(nev, cukorTartalom, tomeg)
        {
            Szin = szin;
        }

        public override void Megeszem(float elfogyasztottSzazalek)
        {
            base.Megeszem(100);
        }

    }
}
