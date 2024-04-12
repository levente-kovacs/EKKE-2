using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Egy könyvnek van:
- írója (string): min. 3 betű, max. 50 betű
- címe (string): min. 3 betű, max. 50 betű
- kiadási éve (egész szám): min. 1910, max. az aktuális év
- ára (egész szám): max. 30e Ft, 5-tel osztható
- műfaja (enum): mese, regény, történelem, szakkönyv, külföldi
- konstruktor az 5 mező kezdőértékével
- konstruktor 3 mező értékével, az aktuális év legyen a kiadási év, a műfaj pedig szakkönyv
 */

namespace Konyvespolc {
    internal class Konyv {
        void StringEllenorzes(string value) {   //ez is default privát
            if (value.Length < 3) {
                throw new Exception("[HIBA] Megadott string hossza kisebb, mint 3 karakter.");
            }
            if (value.Length > 50) {
                throw new Exception("[HIBA] Megadott string hossza nagyobb, mint 50 karakter.");
            }
        }
        public string Iro {
            get {
                return iro;
            }
            set {
                StringEllenorzes(value);
                iro = value;    //value: tárolja az új beállítandó értéket
            }
        }
        private string iro;
        public string Cim {
            get => cim;
            set {
                StringEllenorzes(value);
                cim = value;
            }
        }
        private string cim;
        public ushort KiadasEve { 
            get => kiadasEve;
            set {
                if (value < 1910) {
                    throw new Exception("[HIBA] A kiadás éve túl korai.");
                }
                if (value > DateTime.Now.Year) {
                    throw new Exception("[HIBA] A kiadás évébe még meg se érkeztünk.");
                }
                kiadasEve = value;
            }
        }
        private ushort kiadasEve;
        public ushort Ar {
            get => ar;
            set {
                if (value > 30000) {
                    throw new Exception("[HIBA] Túl drága");
                }
                if (value % 5 != 0) {
                    throw new Exception("[HIBA] Az ár nem osztható 5-el.");
                }
                ar = value; 
            }
        }
        private ushort ar;
        public KonyvMufaj Mufaj { get; set; }   //Auto-implemented property, ha nem kell semmilyen ellenőrzés, még a mögöttes mező is auto-implemented
        public Konyv(string iro, string cim, ushort kiadasEve, ushort ar, KonyvMufaj mufaj) {   //alap, legáltalánosabb konstruktor
            this.Iro = iro;
            this.Cim = cim;
            this.Ar = ar;
            this.KiadasEve = kiadasEve;
            this.Mufaj = mufaj;
        }
        public Konyv(string iro, string cim, ushort ar) : this(iro, cim, (ushort)DateTime.Now.Year, ar, KonyvMufaj.Szakkonyv) {     //this az alap konstruktort hívja meg - paraméterlista egyezés alapján
        }
        public override string ToString() { //nem volt ilyen feladat, de a főprogram kiírás miatt beledobtam
            return $"{iro} - {cim} [{kiadasEve}], műfaja: {Mufaj}, ára: {ar}";
        }
    }
}
