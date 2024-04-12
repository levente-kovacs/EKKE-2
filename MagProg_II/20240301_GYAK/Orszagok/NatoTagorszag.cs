using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Egy NATO tagországot (mint országot) jellemeznek még a következők:

- hadászati ráfordítás: a GDP hány százalékát fordítja hadászati kiadásokra; nemnegatív tört szám
- milyen típusú tag: csak olvasható, értékei: FullMember, PeacePartner, GlobalPartner
- konstruktor az összes mező kezdőértékével
- konstruktor, amely a hadászati ráfordítást alapból a minimális értékre, 0.5%-ra állítja be
- A GDP változtató metódust írd felül úgy, hogy a GDP növelése után még a következőt is végezze le: ha a növelés mértéke (százalékérték) negatív, akkor a hadászati ráfordítást állítsa át a minimális 0.5%-ra!
- ToString metódus: minden adatát formázott sztringként visszaadja
 */
namespace Orszagok {
    internal class NatoTagorszag : Orszag {
        float hadaszatiRaforditas;
        public float HadaszatiRaforditas {
            get => hadaszatiRaforditas;
            private set {
                if (value < 0) {
                    throw new Exception("Negatív hadászati ráfordítás nem lehet, tudod, szerződések.");
                }
                hadaszatiRaforditas = value;
            }
        }
        public enumNatoTagTipus NatoTagsaganakTipusa { get; private set; }
        public NatoTagorszag(string orszagNeve, uint lakossagSzam, float orszagGdp, float hadaszatiRaforditas, enumNatoTagTipus natoTagTipus) : base(orszagNeve, lakossagSzam, orszagGdp) {     //base: ős osztály konstruktor meghívása
            HadaszatiRaforditas = hadaszatiRaforditas;
            NatoTagsaganakTipusa = natoTagTipus;
        }
        public NatoTagorszag(string orszagNeve, uint lakossagSzam, float orszagGdp, enumNatoTagTipus natoTagTipus) : this(orszagNeve, lakossagSzam, orszagGdp, 0.5f, natoTagTipus) {    //this: az alap konstruktor meghívása, ami az ott lévő base miatt már hívja az ős osztály konstruktorát
        }
        public override void gdpAllito(float szazalek) {
            base.gdpAllito(szazalek);
            if (szazalek < 0) {
                HadaszatiRaforditas = 0.5f;
            }
        }
        public override string ToString() {
            return base.ToString() + $", hadászati ráfordítás: {HadaszatiRaforditas:0.00}% NATO tagságának típusa: {NatoTagsaganakTipusa}";
        }
    }
}
