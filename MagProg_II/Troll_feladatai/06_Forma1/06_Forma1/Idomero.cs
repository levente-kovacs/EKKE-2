using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Forma1
{
    internal class Idomero : IEnumerable
    {
        private List<Versenyzo> versenyzok = new List<Versenyzo>();

        public void AddVersenyzo(Versenyzo versenyzo)
        {
            versenyzok.Add(versenyzo);
            versenyzok.Sort();
            //versenyzok.Reverse();

            //if (versenyzok.Count == 0)
            //{
            //    versenyzok.Add(versenyzo);
            //}
            //else if (versenyzok.Count == 1)
            //{
            //    if (versenyzo.CompareTo(versenyzok.First()) > 0)
            //        versenyzok.Insert(0, versenyzo);
            //    else
            //        versenyzok.Add(versenyzo);
            //}
            //else
            //{
            //    if (versenyzo.CompareTo(versenyzok.First()) > 0)
            //        versenyzok.Insert(0, versenyzo);
            //    else if (versenyzok.Last().CompareTo(versenyzo) > 0)
            //        versenyzok.Add(versenyzo);
            //    else
            //    {
            //        for (int i = 0; i < versenyzok.Count - 1; i++)
            //        {
            //            if (versenyzok[i].Ido < versenyzo.Ido && versenyzo.Ido <= versenyzok[i + 1].Ido)
            //                versenyzok.Insert(i + 1, versenyzo);
            //        }
            //    }
            //}
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Versenyzo versenyzo in versenyzok)
            {
                yield return versenyzo.Clone();
            }
        }
    }
}
