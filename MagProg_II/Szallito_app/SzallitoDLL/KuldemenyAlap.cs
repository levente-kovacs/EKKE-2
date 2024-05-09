using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using SzallitoDLL.Exceptions;

namespace SzallitoDLL
{
    internal abstract class KuldemenyAlap : ICloneable, IComparable
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

        private double tomeg;
        public double Tomeg {
            get => tomeg;
            set
            {
                if (value < 0.1)
                    throw new TomegAlacsonyException();                
                tomeg = value;
            }
        }
        public Cim Cim { get; set; }

        public double Terfogat { get { return Szelesseg * Magassag * Melyseg; } }

        public abstract double TerfogatSuly { get; }

        public double VeglegesTomeg
        {
            get => Tomeg > TerfogatSuly ? Tomeg : TerfogatSuly;
        }
        public bool Terfogatsulyos
        {
            get => TerfogatSuly > Tomeg;
        }

        public abstract int KalkulaltAr();

        public override bool Equals(object obj)
        {
            if (obj is KuldemenyAlap)
                return id == (obj as KuldemenyAlap).id;
            return false;
        }

        public abstract object Clone();

        public int CompareTo(object obj)
        {
            if (obj is KuldemenyAlap)
                return VeglegesTomeg > (obj as KuldemenyAlap).VeglegesTomeg ? 1 : -1;
            return -2;
        }

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
