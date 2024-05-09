using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_KonyvesboltDLL
{
    public class Konyvesbolt
    {
        private List<Konyv> konyvek = new List<Konyv>();

        public List<Konyv> Konyvek
        {
            get
            {
                return new List<Konyv>(this.konyvek);
            }
        }

        public void AddKonyv(Konyv konyv)
        {
            konyvek.Add(konyv);
        }

        //f: R -> R, f(x) := x^2
        //f: R -> R, f(x) := x^3
        //f: R -> R, f(x) := 2x^2-4

        //g: {könyvek halmaza} -> R, g(konyv) := k.Ar
        //g: {könyvek halmaza} -> R, g(konyv) := k.Oldalszam

        //public delegate double KonyvToR(Konyv konyv);
        public double Osszeg(Func<Konyv, double> value)
        {
            double osszeg = 0;
            foreach (Konyv konyv in konyvek)
            {
                osszeg += value(konyv);
            }
            return osszeg;
        }

        //public delegate bool KonyvToBool(Konyv konyv);
        //public List<Konyv> Kivalogat(Func<Konyv, bool> predikatum)
        public List<Konyv> Kivalogat(Predicate<Konyv> predikatum)
        {
            List<Konyv> temp = new List<Konyv>();
            foreach (Konyv konyv in konyvek)
            {
                if (predikatum(konyv))
                    temp.Add(konyv);
            }
            return temp;
        }        
    }
}
