using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _03___Orkok
{
    /*
     * class Ork
     *  - int: id: O000001, O000002, stb...
     *  - string: név
     *  - int: életerő
     *  - bool: halott
     *  - int: sebzés
     *  
     *  - void Sebesül(int sebzés)
     *  - void Támad(Ork ork)
     *  - Ork Klon
     *  
     *  - override string ToString()
     *  - override bool Equals(object obj)
     */

    internal class Ork
    {
        private static string ID_PREFIX = "O";
        private static int ID = 1;

        private Ork(int id)
        {
            this.SetId(id);
        }
        public Ork()
        {
            SetId(ID++);
            Eletero = 60;
            Sebzes = 20;
        }
        public Ork(string nev)
           : this()
        {
            Nev = nev;
        }

        private int id;
        private void SetId(int value)
        {
            if (value < 1)
                throw new Exception("Az id nem lehet 1-nél kisebb!");

            id = value;
        }
        private int GetId() { return id; }
        public string Id
        {
            get
            {
                return string.Format("{0}{1}", Ork.ID_PREFIX, id.ToString().PadLeft(6, '0'));
            }
        }

        private string nev;
        public string Nev
        {
            get { return nev; }
            set
            {
                if (value != null)
                {
                    if (value.Contains(' '))
                        throw new Exception("A név csak egy tagból állhat!");

                    foreach (char betu in value)
                    {
                        if (!((60 <= betu && betu <= 90) || (97 <= betu && betu <= 122) || betu == 39))
                            throw new Exception("A név csak angol betűt, illetve aposztrofot tartalmazhat!");
                    }
                }

                nev = value;
            }
        }

        private int eletero;
        public int Eletero
        {
            get { return eletero; }
            private set
            {
                if (value > 100)
                    throw new Exception("Az életerő nem lehet nagyobb, mint 100!");

                eletero = value;
            }
        }
        public bool Halott { get { return Eletero <= 0; } }        

        private int sebzes;
        public int Sebzes
        {
            get { return sebzes; }
            private set
            {
                if (value < 10)
                    throw new Exception("A sebzés nem lehet kisebb, mint 10!");
                if (value > 80)
                    throw new Exception("A sebzés nem lehet nagyobb, mint 80!");

                sebzes = value;
            }
        }

        public void Sebesul(int sebzes)
        {
            if (Halott)
                throw new Exception("Halott ork már nem sebződik!");

            Eletero -= sebzes;
        }
        public void Tamad(Ork ork)
        {
            if (ork.Halott)
                throw new Exception("Halott orkot nem sebzünk meg!");

            ork.Sebesul(this.Sebzes);
        }

        public Ork Klon
        {
            get
            {
                Ork klon = new Ork(id);
                klon.Nev = this.Nev;
                klon.Eletero = this.Eletero;
                klon.Sebzes = this.Sebzes;
                return klon;
            }
        }

        public override string ToString()
        {
            return this.GetType().Name + "{ " +
                "id: " + Id + ", " +
                "név: " + (nev == null ? "-" : Nev) + ", " +
                "eletero: " + Eletero + ", " +
                "halott: " + Halott + ", " +
                "sebzés: " + Sebzes +
                " }";
        }
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (obj == this) return true;
            if (!(obj is Ork)) return false;

            Ork masik = (Ork)obj;

            return this.id == masik.GetId();
        }
    }
}
