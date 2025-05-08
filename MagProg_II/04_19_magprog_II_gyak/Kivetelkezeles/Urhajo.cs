using Kivetelkezeles.comonents;
using Kivetelkezeles.Hibak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetelkezeles
{
    internal class Urhajo
    {
        private string nev;
        public string New { get { return nev; } }

        private int uresTomeg;
        public int UresTomeg { get { return uresTomeg; } }

        private int aktualisTeljesitmeny;
        public int AktualisTeljesitmeny { get { return aktualisTeljesitmeny; } }

        private UrhajoKategoria kategoria;
        public UrhajoKategoria Kategoria { get { return kategoria; } }

        private IKomponens[] komponensek;

        public Urhajo(string nev, int uresTomeg, UrhajoKategoria kategoria)
        {
            if (UresTomeg <= 0)
            {
                throw new ArgumentException("uresTomeg", "Az üres tömeg csak pozitív lehet!");
            }
            if (nev == null)
            {
                throw new ArgumentNullException("nev");
            }

            this.nev = nev;
            this.uresTomeg = uresTomeg;
            this.kategoria = kategoria;
            aktualisTeljesitmeny = 0;

            switch (kategoria)
            {
                case UrhajoKategoria.Yacht:
                    komponensek = new IKomponens[2];
                    break;
                case UrhajoKategoria.Korvett:
                    komponensek = new IKomponens[4];
                    break;
                case UrhajoKategoria.Fregatt:
                    komponensek = new IKomponens[6];
                    break;
                case UrhajoKategoria.Rombolo:
                    komponensek = new IKomponens[8];
                    break;
                case UrhajoKategoria.Teher:
                    komponensek = new IKomponens[8];
                    break;
                case UrhajoKategoria.Allomas:
                    komponensek = new IKomponens[20];
                    break;
                default:
                    break;
            }
        }

        public void KomponensFelszerel(IKomponens komponens)
        {
            for (int i = 0; i < komponensek.Length; i++)
            {
                if (komponensek[i] == null)
                {
                    komponensek[i] = komponens;
                    return;
                }
            }
            throw new KomponensNemFerElKivetel("Az űrhajó betelt.", komponens);
        }

        public void KomponensLeszerel(int index)
        {
            if (komponensek[index] == null)
            {
                throw new KomponensNemTalalhatoKivetel();
            }
            komponensek[index] = null;
        }

        public void Padlogaz()
        {
            try
            {
                for (int i = 0; i < komponensek.Length; i++)
                {
                    if (komponensek[i] is Hajtomu && !komponensek[i].Allapot)
                    {
                        komponensek[i].Aktival();
                        aktualisTeljesitmeny -= komponensek[i].Teljesitmeny;
                        if (aktualisTeljesitmeny < 0) throw new NincsElegEnergiaKivetel(-aktualisTeljesitmeny);
                    }
                }
            }
            catch (NincsElegEnergiaKivetel e)
            {
                foreach (IKomponens k in komponensek)
                {
                    if (k is Hajtomu && k.Allapot == true)
                    {
                        k.Deaktival();
                        aktualisTeljesitmeny += k.Teljesitmeny;
                    }
                }
            }
        }

        public void Beallit()
        {
            for (int i = 0; i < komponensek.Length; i++)
            {
                if (komponensek[i] is Reaktor)
                {
                    try
                    {
                        komponensek[i].Aktival();
                        aktualisTeljesitmeny += komponensek[i].Teljesitmeny;
                    }
                    catch (InvalidOperationException e) { Console.WriteLine(e.Message); }
                    catch (NotSupportedException e) { KomponensLeszerel(i); }
                }
            }
        }

        public void Leallit()
        {
            try
            {
                foreach (IKomponens k in komponensek)
                {
                    k.Deaktival();
                }
            }
            catch (Exception e)
            {
                throw new NemDeaktivalhatoKivetel("Leállítás hiba", e);
            }
            finally { Console.WriteLine("Leállítás megkísérelve..."); }
        }
    }
}
