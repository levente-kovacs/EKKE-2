using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Edesszajuak
{
    internal class Edessegbolt
    {
        private List<Edesseg> edessegek = new List<Edesseg>();

        public bool VanEDiabetikus
        {
            get
            {
                bool vanEDiabetikus = false;
                foreach (Edesseg edesseg in edessegek)
                {
                    if (edesseg.Diabetikus)
                    {
                        vanEDiabetikus = true;
                    }
                }
                return vanEDiabetikus;
            }
        }

        public void AddEdesseg(Edesseg edesseg)
        {
            if (edessegek.Contains(edesseg))
            {
                throw new Exception("[HIBA] Ez az édesség már benne van a memóriában.");
            }
            edessegek.Add(edesseg);
        }

        public float HanyKgDrazseVanASzinbol(Szin szin)
        {
            if (edessegek.Count == 0)
            {
                throw new Exception("[HIBA] Nincs egy édesség sem elmentve.");
            }

            float eredmenyGrammban = 0;

            foreach (Edesseg edesseg in edessegek)
            {
                if (edesseg is Drazse)
                {
                    if ((edesseg as Drazse).Szin == szin)
                    {
                        eredmenyGrammban += edesseg.Tomeg;
                    }
                }
            }

            return eredmenyGrammban / 1000;
        }

        public List<Csokolade> SzurdKiAzIlyenCsokikat(float kakaoTartalom, CsokoladeFajta csokiFajta)
        {
            List<Csokolade> megegyezoCsokik = new List<Csokolade>();
            Csokolade csoki = new Csokolade("", 0f, 0, kakaoTartalom, csokiFajta);
            if (edessegek.Contains(csoki))
            {
                megegyezoCsokik.Add(csoki);
            }
            //foreach (Edesseg edesseg in edessegek)
            //{
            //    if (edesseg is Csokolade)
            //    {
            //    }
            //}
            return megegyezoCsokik;
        }
    }
}
