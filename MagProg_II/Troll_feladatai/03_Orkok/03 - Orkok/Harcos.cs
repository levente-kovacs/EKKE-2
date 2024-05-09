using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03___Orkok
{ 
    /*
     * class Harcos
     *  - int: id: O000001H, O000002H, stb...
     *  - string: név
     *  - int: életerő
     *  - bool: halott
     *  - int: sebzés
     *  - int: pajzs
     *  - Fegyver: fegyver (név, sebzés)
     *  
     *  - void Sebesül(int sebzés) - máshogyan
     *  - void Támad(Ork ork) - máshogyan
     *  - Ork Klon - máshogyan
     *  
     *  - override string ToString() - máshogyan
     *  - override bool Equals(object obj)
     */
    internal class Harcos : Ork
    {
        private Harcos(int id) : base(id) { }
        public Harcos(Fegyver fegyver) : this(null, fegyver)
        {
        }
        public Harcos(string nev, Fegyver fegyver) : base(nev)
        {
            this.Eletero = 80;
            this.Sebzes = 30;
            this.Fegyver = fegyver;
            this.Pajzs = 10;
        }

        public Fegyver Fegyver { get; set; }
        public int Pajzs { get; set; }

        public override void Sebesul(int sebzes)
        {
            if (Halott)
                throw new Exception("Halott ork már nem sebződik!");

            Eletero -= sebzes - this.Pajzs;
        }
        public override void Tamad(Ork ork)
        {
            if (ork.Halott)
                throw new Exception("Halott orkot nem sebzünk meg!");

            ork.Sebesul(this.Sebzes + this.Fegyver.Sebzes);
        }

        public override Ork Klon
        {
            get
            {
                Harcos klon = new Harcos(this.GetId());
                klon.Nev = this.Nev;
                klon.Eletero = this.Eletero;
                klon.Pajzs = this.Pajzs;
                klon.Fegyver = this.Fegyver;
                return klon;
            }
        }

        public override string ToString()
        {
            string szoveg = base.ToString().Replace(" }", "");
            szoveg += "pajzs: " + Pajzs + ", ";
            szoveg += Fegyver;
            szoveg += " }";
            return szoveg;
        }
    }
}
