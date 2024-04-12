using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
  Név: nem null, legalább 3 karakter, egyszer módosítható (az érték csak hosszabb lehet a változtatás 
után), kívülről nem módosítható 
• Midikloriánok: egész szám az (5000, 70000] intervallumól 
• Kard színe: felsorolás típus (ZOLD, KEK, LILA, SARGA, NARANCS, FEHER) 
• Mester: logikai érték, igaz érték után nem vehet föl hamisat 
• Konstruktor: Paraméterben bekéri a nevet és a midiklorián számot, majd elmenti azokat. A kard színét 
automatikusan kékre, a mester változót hamisra állítja. 
• Konstruktor: Paraméterben bekéri a nevet, a midiklorián számot, a kard színét és hogy mester-e, majd 
elmenti azokat. Amennyiben mester, a névadás után meghívja a MesterreValik() metódust. 
• MesterreValik(): publikus metódus. Ha a jedi már mester, dobjon kivételt! Az adott jedi nevéhez 
hozzáfűzi a „Mester” utótagot, és igazra állítja a Mester értéket.
 */
namespace Jedik {
    internal class Jedi {
		private bool voltNevModositva = false;
		private string nev;
		public string Nev {
			get => nev;
			private set {
				if (value == null) {
					throw new Exception("[HIBA] Üres a név");
				}
				if (value.Length < 3) {
					throw new Exception("[HIBA] A név hossza rövid");
				}
				if (voltNevModositva) {
					throw new Exception("[HIBA] A név egyszer már volt módosítva.");
				}
				nev = value;
			}
		}
		private int midiklorianokSzama;
		public int MidiklorianokSzama {
			get => midiklorianokSzama;
			private set {
				if (value <= 5000) {
					throw new Exception("[HIBA] Túl kevés a midiizé száma");
				}
                if (value > 70000) {
                    throw new Exception("[HIBA] Túl sok a midiizé száma");
                }
                midiklorianokSzama = value;
			}
		}
        public KardSzinek KardSzine { get; private set; }	//auto-implementnél is lehet private a set
		private bool mester;
		public bool Mester {
			get => mester;
			private set {
				if (mester) {
					throw new Exception("[HIBA] Nem engedett a mester fokozatának basztatása.");
				}
				mester = value; 
			}
		}
		public void MesterreValik() {
			Mester = true;
			//if (mester) {	//Ez nem kell, mert a Mester property állításánál ugyanazt ellenőrizzük
			//	throw new Exception("[HIBA] Ez nem a magyar parlament, nem lehet halmozni a tisztségeket.");
			//}
			Nev += " Mester";
			voltNevModositva = true;
		}
        public Jedi(string nev, int midiklorianokSzama, KardSzinek kardSzine, bool mester) {
            Nev = nev;
            MidiklorianokSzama = midiklorianokSzama;
            KardSzine = kardSzine;
			if (mester) {
				MesterreValik();
			}
        }
        public Jedi(string nev, int midiklorianokSzama) : this(nev, midiklorianokSzama, KardSzinek.KEK, false) {
		}
        public override string ToString() {
            return $"{nev} ({midiklorianokSzama}) {KardSzine} karddal hadonászik, mint egy idióta...";
        }
    }
}
