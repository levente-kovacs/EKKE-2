using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Forma1
{
    internal class Versenyzo : ICloneable, IComparable
    {
        private Versenyzo() { }
        public Versenyzo(string nev, Csapat csapat, string ido)
        {
            this.Nev = nev;
            this.Csapat = csapat;
            this.Ido = new TimeSpan(0, 0,
                int.Parse(ido.Substring(0, 2)),
                int.Parse(ido.Substring(3, 2)),
                int.Parse(ido.Substring(6)));
        }

        public string Nev { get; set; }
        public Csapat Csapat { get; set; }
        public TimeSpan Ido { get; set; }

        public override string ToString()
        {
            return string.Format("Versenyzo [ név: {0}, csapat: {1}, idő: {2} ]",
                this.Nev,
                this.Csapat,
                this.Ido.ToString(@"mm\:ss\.fff"));
        }

        public object Clone()
        {
            //Sekély klónozás
            //Versenyzo klon = new Versenyzo();
            //klon.Nev = this.Nev;
            //klon.Csapat = Csapat;
            //klon.Ido = this.Ido;
            //return klon;

            //return this.MemberwiseClone();

            //Mély klónozás
            Versenyzo klon = new Versenyzo();
            klon.Nev = this.Nev;
            klon.Csapat = (Csapat)Csapat.Clone();
            klon.Ido = this.Ido;
            return klon;
        }

        /// <summary>
        /// - >0: this nagyobb, mint obj
        /// - <0: this kisebb, mint obj
        /// - 0: this és obj egyenlőek
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int CompareTo(object obj)
        {
            if (!(obj is Versenyzo)) throw new Exception();
            if (this == obj) return 0;

            Versenyzo masik = (Versenyzo)obj;

            if (this.Ido < masik.Ido) return 1;
            if (this.Ido > masik.Ido) return -1;
            return 0;
        }
    }
}
