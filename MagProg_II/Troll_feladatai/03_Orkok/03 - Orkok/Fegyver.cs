using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03___Orkok
{
    internal class Fegyver
    {
        public Fegyver(string nev, int sebzes)
        {
            Nev = nev;
            Sebzes = sebzes;
        }

        public string Nev { get; set; }
        public int Sebzes { get; set; }

        public override string ToString()
        {
            string szoveg = "Fegyver { ";
            szoveg += "név: " + Nev + ", ";
            szoveg += "sebzés: " + Sebzes;
            szoveg += " }"; 
            return szoveg;
        }
    }
}
