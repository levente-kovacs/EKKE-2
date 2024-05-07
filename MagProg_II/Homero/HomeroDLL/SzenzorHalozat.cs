using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeroDLL
{
    public class SzenzorHalozat : IEnumerable, ICloneable
    {
        private List<Szenzor> szenzorok = new List<Szenzor>();

        //private List<Szenzor> aktivSzenzorok = new List<Szenzor>();

        public List<Szenzor> AktivSzenzorok {
            get
            {
                List<Szenzor> aktivSzenzorok = szenzorok.Where(s => s.Aktiv)
                                                        .OrderBy(s => s.Pozicio.x)
                                                        .ThenByDescending(s => s.Pozicio.y)
                                                        .ToList();
                aktivSzenzorok.ForEach(s => s.Clone());
                return aktivSzenzorok;
            }
        }
        
        public void Telepit(Szenzor szenzor)
        {
            szenzorok.Add(szenzor);
        }

        public delegate int HomeroToInt(Homero homero);
        public double AktivAtlag(HomeroToInt pred)
        {
            double sum = 0;
            int count = 0;
            foreach (Homero homero in szenzorok)
            {
                if (homero.Aktiv)
                {
                    sum += pred(homero);
                    count++;
                }
            }
            return sum / count;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Szenzor szenzor in szenzorok)
            {
                if (szenzor.Aktiv)
                    yield return szenzor.Clone();
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
