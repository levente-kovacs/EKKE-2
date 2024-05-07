using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeroDLL.Exceptions
{
    public class SzenzorInaktivException : Exception
    {
        public SzenzorInaktivException() : base("A szenzor inaktív.")
        {
        }

    }
}
