using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
A könyveket egy könyvespolcon tároljuk, amely:

Tárolja könyveknek egy listáját.
- AddBook(...) eljárás: paramétere egy könyv, amelyet a könyvespolc listába kívánunk helyezni
- TotalPrice: csak olvasható property, megadja a könyvespolcon tárolt könyvek összértékét
- Search(...) függvény: egy paramétere egy író neve (string), visszatér könyvek egy listájával, amelyek a könyvespolcon vannak tárolva, és amelyeknek az írója a megadott. Ha nem talál ilyen könyvet, akkor 0 elemű listával tér vissza. 
 */
namespace Konyvespolc {
    internal class KonyvesPolc {
        private List<Konyv> listKonyvesPolc = new List<Konyv>();
        public void AddBook(Konyv ujKonyv) {
            listKonyvesPolc.Add(ujKonyv);
        }
        public int TotalPrice {
            get {
                return listKonyvesPolc.Sum(konyvAr => konyvAr.Ar);  //lambda, a list-ben lévő Konyv objektum Ar property-ket sum-olja össze
            }
        }
        public List<Konyv> Search(string iroNeve) {
            return listKonyvesPolc.Where(aktKonyv => aktKonyv.Iro == iroNeve).ToList();     //lambda, leszűri a listKonyvesPolc azon elemeit ami megfelel a feltételnek, kell a ToList() a végére
        }
    }
}
