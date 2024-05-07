using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HomeroDLL.Exceptions
{
    public class AlacsonyAlsoHatarException : Exception
    {
        public AlacsonyAlsoHatarException() : base("A szenzor alsó határa túl alacsony.")
        {
        }
    }
}
