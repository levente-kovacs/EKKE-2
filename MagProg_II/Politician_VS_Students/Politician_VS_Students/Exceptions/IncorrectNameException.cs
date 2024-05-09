using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Politician_VS_Students.Exceptions
{
    internal class IncorrectNameException : Exception
    {
        public IncorrectNameException() : base("Person name is not correct.")
        {
        }
    }
}
