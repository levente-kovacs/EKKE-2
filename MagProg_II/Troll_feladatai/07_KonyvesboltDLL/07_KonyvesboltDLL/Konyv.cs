using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_KonyvesboltDLL
{
    public class Konyv
    {
        private static Random rnd = new Random();

        public Konyv(string szerzo, string cim, int ar, bool eKonyv, Mufaj mufaj)
        {
            this.Szerzo = szerzo;
            this.Cim = cim;
            this.Mufaj = mufaj;
            this.Ar = ar;
            this.Oldalszam = rnd.Next(130, 850);
            this.EKonyv = eKonyv;
        }
        public Konyv(string szerzo, string cim, bool eKonyv, Mufaj mufaj)
        {
            this.Szerzo = szerzo;
            this.Cim = cim;
            this.Mufaj = mufaj;
            this.Oldalszam = rnd.Next(130, 850);
            this.EKonyv = eKonyv;
        }

        public string Szerzo { get; set; }
        public string Cim { get; set; }
        public int Oldalszam { get; set; }
        public bool EKonyv { get; set; }
        public Mufaj Mufaj { get; set; }

        private bool arMegadva = false;
        private int ar;
        public int Ar
        {
            get { return ar; }
            set
            {
                if (value < 500)
                    throw new AlacsonyArException();
                if (value > 50000)
                    throw new MagasArException(value);

                ar = value;
                arMegadva = true;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}, {2} Ft{3}, {4}",
                Szerzo,
                Cim,
                arMegadva ? Ar.ToString() : "-",
                EKonyv ? " (e-könyv)" : "",
                Mufaj);
        }
    }
}
