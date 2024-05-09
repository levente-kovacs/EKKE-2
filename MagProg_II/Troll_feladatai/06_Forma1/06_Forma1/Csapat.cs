using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _06_Forma1
{
    internal class Csapat : ICloneable
    {
        public Csapat(string nev)
        {
            Nev = nev;
        }

        public string Nev { get; set; }
        public string LogoURL { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return Nev;
        }
    }
}
