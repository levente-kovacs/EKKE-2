using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    enum Szin { piros, kek, zold, barna, szurke, fekete }
    enum Tipus { kombi, szedan }
    internal class Auto
    {
        public int AjtokSzama { get; set; }
        public Szin Szin { get; set; }
        public string Gyarto { get; set; }
        public Tipus Tipus { get; set; }
        public int Evjarat { get; set; }

        public Auto(int ajtokSzama, Szin szin, string gyarto, Tipus tipus, int evjarat)
        {
            AjtokSzama = ajtokSzama;
            Szin = szin;
            Gyarto = gyarto;
            Tipus = tipus;
            Evjarat = evjarat;
        }
    }
}
