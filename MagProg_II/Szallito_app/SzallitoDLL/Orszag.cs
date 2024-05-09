using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzallitoDLL
{
    internal class Orszag
    {
        public Orszag(string orszagKod, bool euTagallam)
        {
            this.OrszagKod = orszagKod;
            this.EuTagallam = euTagallam;
        }

        public string OrszagKod { get; set; }
        public bool EuTagallam { get; set; }
    }
}
