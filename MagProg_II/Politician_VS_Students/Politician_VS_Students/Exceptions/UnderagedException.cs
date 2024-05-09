using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Politician_VS_Students.Exceptions
{
    internal class UnderagedException : Exception
    {
        public UnderagedException() : base("The person is underage.")
        {
        }
    }
}
