using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzallitoDLL
{
    internal class Kuldemeny : KuldemenyAlap, IBiztositas
    {
        private static double TERFOGATSULY_EGYUTTHATO = 139.0;
        private static int TERFOGATSULY_ALAP_AR = 2850;
        private static int ALAP_AR = 1950;
        private static int AR_KILOGRAMMONKENT = 950;
        private static int EUN_KIVULI_FELAR = 1350;

        public Kuldemeny(int szelesseg, int magassag, int melyseg, double tomeg, string orszagKod, string varos, BiztositasTipus biztositasTipus = BiztositasTipus.Nincs)
                  : base(szelesseg, magassag, melyseg, tomeg, orszagKod, varos)
        {
        }

        public override double TerfogatSuly => Terfogat / 1000000 / TERFOGATSULY_EGYUTTHATO;

        public BiztositasTipus BiztositasTipus { get; set; }

        public override int KalkulaltAr()
        {
            double tomegSzorAr = VeglegesTomeg * AR_KILOGRAMMONKENT;
            if (Terfogatsulyos)
                return (int)(TERFOGATSULY_ALAP_AR + tomegSzorAr);
            else
                return (int)(ALAP_AR + tomegSzorAr);
        }

        public override object Clone()
        {
            return this.MemberwiseClone();
        }

        public int Biztositas(int ertek)
        {
            switch (BiztositasTipus)
            {
                case BiztositasTipus.Alap:
                    return (int)(ertek * 0.1);
                case BiztositasTipus.Extra:
                    return (int)(ertek * 0.2);
                default:
                    return 0;
            }
        }


        //public override string ToString()
        //{
        //    return base.ToString() +
        //        (BiztositasTipus != BiztositasTipus.Nincs ? " (Bizt.: " + BiztositasTipus.ToString() + ")" : "");
        //}
    }
}
