using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Egy AU (African Union) tagországot (mint országot) jellemeznek még a következők:

- hivatalos nyelv: csak olvasható, értékei: Arabic, English, French, Portuguese, Spanish, Swahili, OtherAfricanLanguages
- konstruktor az összes mező kezdőértékével
- ToString metódus: minden adatát formázott sztringként visszaadja
 */
namespace Orszagok {
    internal class AUTagorszag : Orszag {
        public enumAUHivatalosNyelv AUHivatalosNyelv { get; private set; }
        public AUTagorszag(string orszagNeve, uint lakossagSzam, float orszagGdp, enumAUHivatalosNyelv AUHivatalosNyelv) : base(orszagNeve, lakossagSzam, orszagGdp) {     //base: ős osztály konstruktor meghívása
            this.AUHivatalosNyelv = AUHivatalosNyelv;
        }
        public override string ToString() {
            return base.ToString() + $", hivatalos nyelv: {AUHivatalosNyelv}";
        }
    }
}
