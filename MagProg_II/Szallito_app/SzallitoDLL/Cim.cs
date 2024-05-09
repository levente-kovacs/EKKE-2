﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using SzallitoDLL.Exceptions;

namespace SzallitoDLL
{
    internal class Cim : ICloneable
    {
        private static List<Orszag> ORSZAGOK = new List<Orszag>()
        {
                new Orszag( "H", true ),
                new Orszag( "UA", false ),
                new Orszag( "EST", true ),
                new Orszag( "VN", false ),
                new Orszag( "RO", true ),
                new Orszag( "SK", true ),
                new Orszag( "ARM", false ),
                new Orszag( "ROK", false ),
                new Orszag( "D", true ),
                new Orszag( "A", true ),
                new Orszag( "I", true ),
                new Orszag( "NL", true ),
                new Orszag( "DK", true ),
                new Orszag( "SYR", false ),
                new Orszag( "TN", false ),
                new Orszag( "F", true )
        };

        public Cim(string orszagKod, string varos)
        {
            OrszagKod = orszagKod;
            Varos = varos;
        }

        public string OrszagKod { get; set; }
        public string Varos { get; set; }
        public bool EuTagallam
        {
            get
            {
                if (ORSZAGOK.Any(o => o.OrszagKod == OrszagKod && o.EuTagallam))
                    return true;
                else
                    throw new OrszagkodNemTalalhatoException(OrszagKod);
            }
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return String.Format("{0} ({1})", Varos, OrszagKod);
        }

    }
}
