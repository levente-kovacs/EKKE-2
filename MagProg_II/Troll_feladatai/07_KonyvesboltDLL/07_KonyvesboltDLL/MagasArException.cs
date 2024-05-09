using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_KonyvesboltDLL
{
    public class MagasArException : Exception
    {
        public MagasArException(int tulMagasAr) : base("Túl magas ár.")
        {
            this.TulMagasAr = tulMagasAr;
        }

        public readonly int TulMagasAr;
    }
}
