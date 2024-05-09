using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SzallitoDLL.Exceptions
{
    internal class OrszagkodNemTalalhatoException : Exception
    {
        protected OrszagkodNemTalalhatoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
