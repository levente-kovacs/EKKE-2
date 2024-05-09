using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2___App
{
    internal class Kuldemeny
    {
        private static double TERFOGATSULY_EGYUTTHATO = 139.0;
        private static int TERFOGATSULY_ALAP_AR = 2850;
        private static int ALAP_AR = 1950;
        private static int AR_KILOGRAMMONKENT = 950;
        private static int EUN_KIVULI_FELAR = 1350;

        public Kuldemeny(int szelesseg, int magassag, int melyseg, double tomeg, 
            string orszagKod, string varos)
        {
            
        }

        //public override string ToString()
        //{
        //    return base.ToString() +
        //        (BiztositasTipus != BiztositasTipus.Nincs ? " (Bizt.: " + BiztositasTipus.ToString() + ")" : "");
        //}
    }
}
