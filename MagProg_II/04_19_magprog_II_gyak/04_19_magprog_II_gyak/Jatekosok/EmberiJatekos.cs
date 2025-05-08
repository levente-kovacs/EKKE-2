using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_19_magprog_II_gyak.Jatekosok
{
    internal class EmberiJatekos : ITippelo
    {
        public object Clone()
        {
            // nincs mezőm => shallow copy
            return MemberwiseClone(); // az object-től örökölt metódussal shallow copy-t tudunk készíteni
        }

        public void JatekIndul(int alsoHatar, int felsoHatar)
        {
            Console.WriteLine($"Játék elkezdődött a [{alsoHatar}; {felsoHatar}] intervallumon.");
        }

        public int KovetkezoTipp()
        {
            Console.Write("A következő tipped: ");
            return int.Parse(Console.ReadLine());
        }

        public void Nyert()
        {
            Console.WriteLine("Gratulálnuk, nyertél!");
        }

        public void Veszitett()
        {
            Console.WriteLine("Sajnáljuk, vesztettél.");
        }
    }
}
