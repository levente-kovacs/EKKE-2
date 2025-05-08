using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_19_magprog_II_gyak.Jatekosok
{
    // abstract osztály konstruktorából közvetlenül nem lehet példányosítani
    internal abstract class GepiJatekosok : ITippelo
    {
        private int alsoHatar;
        protected int AlsoHatar {  get { return alsoHatar; } }
        private int felsoHatar;
        protected int FelsoHatar {  get { return felsoHatar; } }
        private int nyertDB;
        private int veszitettDB;

        public GepiJatekosok()
        {
            nyertDB = 0;
            veszitettDB = 0;
        }
        
        public object Clone()
        {
            return MemberwiseClone();
        }

        public void JatekIndul(int alsoHatar, int felsoHatar)
        {
            this.alsoHatar = alsoHatar;
            this.felsoHatar = felsoHatar;
        }

        public void Nyert()
        {
            nyertDB++;
        }

        public void Veszitett()
        {
            veszitettDB++;
        }

        // jelenleg nem tudom megoldani a függvény kifejtését => abstract osztályban abstract metódus
        public abstract int KovetkezoTipp(); // csak szignatúra

    }
}
