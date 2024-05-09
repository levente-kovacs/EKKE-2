using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Politician_VS_Students.Exceptions
{
    internal class NoCompetenceException : Exception
    {
        public NoCompetenceException() : base("Az adott ember elhülyült.")
        {
        }
    }
}
