using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03___Orkok
{
    internal class Horda
    {
        public Horda()
        {
            this.orkok = new List<Ork>();
        }

        private List<Ork> orkok;        
        public List<Ork> Orkok
        {
            get
            {
                if (this.orkok.Count == 0)
                    throw new Exception("A horda jelenleg üres!");

                List<Ork> temp = new List<Ork>();
                foreach (Ork ork in this.orkok)
                {
                    temp.Add(ork.Klon);
                }
                return temp;
            }
        }
        public List<Harcos> Harcosok
        {
            get
            {
                if (this.orkok.Count == 0)
                    throw new Exception("A horda jelenleg üres!");

                List<Harcos> temp = new List<Harcos>();
                foreach (Ork ork in orkok)
                {
                    if (ork is Harcos)
                        temp.Add((Harcos)ork.Klon);
                }
                return temp;
            }
        }
      
        public Harcos LegveszelyesebbHarcos
        {
            get
            {
                if (this.orkok.Count == 0)
                    throw new Exception("A horda jelenleg üres!");

                Harcos legveszelyesebb = null;
                foreach (Ork ork in orkok)
                {
                    if (ork is Harcos)
                    {
                        Harcos temp = (Harcos)ork;
                        if (legveszelyesebb == null ||
                            legveszelyesebb.Sebzes + legveszelyesebb.Fegyver.Sebzes <
                            temp.Sebzes + temp.Fegyver.Sebzes)
                        {
                            legveszelyesebb = temp;
                        }
                    }
                }

                if (legveszelyesebb == null)
                    throw new Exception("A hordában nincsenek harcosok!");

                return legveszelyesebb.Klon as Harcos;
            }
        }

        public Harcos LegerosebbPajzsuHarcos
        {
            get { throw new NotImplementedException(); }
        }

        public List<Harcos> AdottFegyvertHasznaloHarcosok(string fegyverNev)
        {
            throw new NotImplementedException();
        }

        public Ork LeggyengebbOrk
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void AddOrk(Ork ork)
        {
            if (this.orkok.Contains(ork))
                throw new Exception("Az ork már szerepel a listában!");

            this.orkok.Add(ork.Klon);
        }       
    }
}
