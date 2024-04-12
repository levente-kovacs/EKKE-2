using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
A térképen (mint konténerosztályban) országok sokaságát tároljuk. Írj property-ket/metódusokat ehhez az osztályhoz:

- Új ország hozzáadása: Ne lehessen már létező nevű országot hozzáadni, egyébként dobj kivételt!
- Melyik a legnépesebb ország?
- Mennyi az átlagos GDP?
- Melyik a legnépesebb olyan AU tagország, amelynek a hivatalos nyelve az, amit a paraméterben megadunk?
- Mi a listája azokat a teljes jogú NATO tagországoknak, melyek legalább annyit költenek harcászatra, amennyit paraméterben megadunk?
 */
namespace Orszagok {
    internal class Terkep {
        private List<Orszag> orszagokListaja = new List<Orszag>();
        public void OrszagHozzaadasa(Orszag ujOrszag) {
            if (orszagokListaja.Contains(ujOrszag)) {
                throw new Exception($"[HIBA] {ujOrszag} már rajta van a térképen.");
            }
            orszagokListaja.Add(ujOrszag);
        }
        public Orszag LegnepesebbOrszag {
            get {
                return orszagokListaja.First(orszag => orszag.LakossagSzam == orszagokListaja.Max(orszag => orszag.LakossagSzam));  //mint Jediknél, kikeressük azt az országot, ahol a lakosságszám megegyezik a listában lévő legnagyobb értékű lakosságszámmal
            }
        }
        public double AtlagosGDP {
            get {
                return orszagokListaja.Average(orszag => orszag.OrszagGdp);
            }
        }
        public AUTagorszag legnepesebbAUTagorszagAdottNyelvvel(enumAUHivatalosNyelv hivatalosNyelv) {
            //Első körben egy listába átszűrjük azokat az országokat amik AU országok és hivatalos nyelvük az amit keresünk
            List<AUTagorszag> szurtOrszagLista = new List<AUTagorszag>();
            foreach (var orszag in orszagokListaja) {
                if (orszag is AUTagorszag) {
                    AUTagorszag auOrszag = orszag as AUTagorszag;
                    if (auOrszag.AUHivatalosNyelv == hivatalosNyelv) {
                        szurtOrszagLista.Add(auOrszag);
                    }
                }
            }
            return szurtOrszagLista.First(orszag => orszag.LakossagSzam == szurtOrszagLista.Max(orszag => orszag.LakossagSzam));    //már a szűrt listából szedjük ki a legnagyobb népeságű országot
        }
        public List<NatoTagorszag> teljesNatoTagorszagok(float minHarcKiad) {
            List<NatoTagorszag> kivalasztottOrszagok = new List<NatoTagorszag>();
            foreach (var orszag in orszagokListaja) {
                if (orszag is NatoTagorszag) {
                    NatoTagorszag natoTag = orszag as NatoTagorszag;
                    if (natoTag.NatoTagsaganakTipusa == enumNatoTagTipus.FullMember && natoTag.HadaszatiRaforditas >= minHarcKiad) {
                        kivalasztottOrszagok.Add(natoTag);
                    }
                }
            }
            return kivalasztottOrszagok;
        }
        public List<Orszag> osszesOrszag {
            get {
                return orszagokListaja;
            }
        }
    }
}
