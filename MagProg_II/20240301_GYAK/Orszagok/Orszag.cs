using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Egy országot jellemeznek a következők:

- ország neve: csak olvasható, nem null, nem üres string, legalább 2 betű
- lakosságszám: pozitív egész szám
- GDP (millió USD-ben): csak olvasható, pozitív tört szám
- konstruktor a 3 mező kezdőértékével
- GDP változtató eljárás: egy százalékértéket (akár negatívat is) kap paraméterül, mellyel meg kell növelnie az aktuális GDP-t
- ToString metódus: minden adatát formázott sztringként visszaadja
 */
namespace Orszagok {
    internal class Orszag {
		private string orszagNeve;
		public string OrszagNeve {
			get => orszagNeve;
			private set {	//lehet private, nem kell protected, base miatt konstruktor lesz meghívva, így az eléri a private elemeket is gyerek osztályban
				if (value == null) { 
					throw new Exception("[HIBA] Város neve nem lehet null.");
				}
				if (value.Length < 2) {
					throw new Exception("[HIBA] Város nevének hossza túl rövid.");
				}
				orszagNeve = value; 
			}
		}
		private uint lakossagSzam;
		public uint LakossagSzam {
			get => lakossagSzam;
			set {
				if (value == 0) {
					throw new Exception("Azért legalább egy tarka birka lakos legyen már, nah...");
				}
				lakossagSzam = value; 
			}
		}
		private float orszagGdp;
		public float OrszagGdp {
			get => orszagGdp;
			private set {	//lehet private, nem kell protected, base miatt konstruktor lesz meghívva, így az eléri a private elemeket is gyerek osztályban
                if (value <= 0) {
					throw new Exception("Negatív GDP nincs engedélyezve.");
				}
				orszagGdp = value; 
			}
		}
        public Orszag(string orszagNeve, uint lakossagSzam, float orszagGdp) {
            OrszagNeve = orszagNeve;
            LakossagSzam = lakossagSzam;
            OrszagGdp = orszagGdp;
        }
		public virtual void gdpAllito(float szazalek) {		//virtuális: hogy gyerek osztályban override-olható legyen (property is lehet virtuál, nem csak metódus)
			OrszagGdp *= 1 + szazalek / 100;
		}
        public override string ToString() {
            return $"{orszagNeve} éves GDP: {OrszagGdp:n} millió USD lakosság száma: {LakossagSzam:n0} fő";		//:n0 ezres tagolás kiíráskor tizedesértékek nélkül
        }
        public override bool Equals(object? obj) {  //Egyenlőség vizsgálat 2 objektum között - this és paraméterként megkapott objektum között: ez az override kihatással van a contains vizsgálatra
			if (obj is Orszag) {
				Orszag orszag = obj as Orszag;
				return this.OrszagNeve == orszag.OrszagNeve;
			}
			return false;
        }
    }
}
