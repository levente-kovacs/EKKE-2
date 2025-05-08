using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_19_magprog_II_gyak
{
    internal class SzamKitalaloJatek
    {
        private static Random rnd = new Random();
        private List<ITippelo> versenyzok;
        private int alsoHatar;
        private int felsoHatar;
        private int cel; // gondolt szám
        public int VersenyzokSzama { get { return versenyzok.Count; } }
        public void VersenyzoFelvesz(ITippelo versenyzo)
        {
            versenyzok.Add(versenyzo);
        }
        public ITippelo this[int index]
        {
            get
            {
                return (versenyzok[index].Clone() as ITippelo);
            }
        }

        public SzamKitalaloJatek(int alsoHatar, int felsoHatar)
        {
            this.alsoHatar = alsoHatar;
            this.felsoHatar = felsoHatar;
            versenyzok = new List<ITippelo>();
        }

        private void versenyIndul()
        {
            cel = rnd.Next(alsoHatar, felsoHatar + 1);
            foreach (ITippelo versenyzo in versenyzok)
            {
                versenyzo.JatekIndul(alsoHatar, felsoHatar);
            }
        }

        private bool mindenkiTippel()
        {
            bool voltENyertes = false;
            for (int i = 0; i < versenyzok.Count; i++)
            {
                if (versenyzok[i].KovetkezoTipp() == this.cel)
                {
                    versenyzok[i].Nyert();
                    if (!voltENyertes)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            versenyzok[j].Veszitett();
                        }
                        voltENyertes = true;
                    }
                }
                else if (voltENyertes)
                {
                    versenyzok[i].Veszitett();
                }
            }
            return voltENyertes;
        }

        public void Jatek()
        {
            versenyIndul();
            while (!mindenkiTippel()) ; // addig ismétlem, amíg valaki nem nyer
        }
    }
}
