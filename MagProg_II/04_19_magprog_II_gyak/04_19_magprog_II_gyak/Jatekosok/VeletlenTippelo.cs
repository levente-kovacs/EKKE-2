using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_19_magprog_II_gyak.Jatekosok
{
    // abstract ős
    //  1) én is abstract leszek - nem kell implementálni az őstől származó abstract-okat
    //  2) megvalósítom az őstől származó összes abstract-ot
    internal class VeletlenTippelo : GepiJatekosok
    {
        private static Random rnd = new Random();
        // az abstract elemeket override-olni kell
        public override int KovetkezoTipp()
        {
            return rnd.Next(AlsoHatar, FelsoHatar + 1);
        }
    }
}
