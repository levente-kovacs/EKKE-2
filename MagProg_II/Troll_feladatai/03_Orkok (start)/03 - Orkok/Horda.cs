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
                List<Ork> temp = new List<Ork>();
                foreach (Ork ork in this.orkok)
                {
                    temp.Add(ork.Klon);
                }
                return temp;
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
