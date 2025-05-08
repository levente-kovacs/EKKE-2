using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetelkezeles.Hibak
{
    internal class NemDeaktivalhatoKivetel : Exception
    {
        public NemDeaktivalhatoKivetel(string? message, Exception hiba) : base(message, hiba)
        {
        }
    }
}
