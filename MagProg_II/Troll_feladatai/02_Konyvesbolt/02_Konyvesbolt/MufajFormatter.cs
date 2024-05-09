using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Konyvesbolt
{
    internal static class MufajFormatter
    {
        public static string Format(Mufaj mufaj)
        {
            switch (mufaj)
            {
                case Mufaj.NemDefinialt: return "Nem definiált";
                case Mufaj.SciFi: return "sci-fi";
                case Mufaj.Drama: return "dráma";
                case Mufaj.Romantikus: return "romantikus";
                case Mufaj.Tortenelmi: return "történelmi";
                case Mufaj.Fantasy: return "fantasy";
                case Mufaj.Horror: return "horror";
                default: throw new Exception("Nem definiált műfaj!");
            }
        }
    }
}
