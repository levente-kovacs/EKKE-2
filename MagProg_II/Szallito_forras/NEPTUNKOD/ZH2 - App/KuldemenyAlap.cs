using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2___App
{
    internal class KuldemenyAlap
    {
        private static int ID = 1;

        protected KuldemenyAlap(int szelesseg, int magassag, int melyseg, double tomeg, string orszagKod, string varos)
        {
            this.id = ID++;
            Szelesseg = szelesseg;
            Magassag = magassag;
            Melyseg = melyseg;
            Tomeg = tomeg;
            Cim = new Cim(orszagKod, varos);
        }

        private int id;
        public string Id { get { return "EP" + id.ToString().PadLeft(4, '0'); } }
        public int Szelesseg { get; set; }
        public int Magassag { get; set; }
        public int Melyseg { get; set; }
        public double Tomeg { get; set; }
        public Cim Cim { get; set; }

        public double Terfogat { get { return Szelesseg * Magassag * Melyseg; } }               

        //public override string ToString()
        //{
        //    return String.Format("{0}: {1}, {2} x {3} x {4}, {5:.00} kg {6} Ft{7}",
        //        Id,
        //        Cim,
        //        Szelesseg, Magassag, Melyseg,
        //        VeglegesTomeg,
        //        KalkulaltAr(),
        //        Terfogatsulyos ? " (TS)" : "");
        //}
    }
}
