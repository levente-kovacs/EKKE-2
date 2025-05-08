using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetelkezeles.Hibak
{
    // minden hiba az Exception leszármazottja közvetett, vagy közvetlen múdon.
    internal class KomponensNemTalalhatoKivetel : Exception
    {
        //  a) saját adatokat kérünk be a konstruktorban, ezeket tároljuk, és később rendelkezésre bocsátjuk
        //  b) pontosabb hibakezelés, hiszen a kivételkezelés hibatípus alapján fog történni
        //  c) az adatok azon körét, amit az ős tud kezelni, csak bekérem és továbbadom neki az ős konstruktor hívás során
        //      Exception(), Exception(üzenet), Exception(üzenet, belső kivétel)
        public KomponensNemTalalhatoKivetel() { }
        public KomponensNemTalalhatoKivetel(string uzenet)
            : base(uzenet) { }
    }
}
