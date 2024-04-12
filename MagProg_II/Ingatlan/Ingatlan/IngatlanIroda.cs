using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingatlan {
    internal class IngatlanIroda {
        List<Ingatlan> listIngatlanok = new List<Ingatlan>();
        public List<CsaladiHaz> CsaladiHazakListaja {
            get {
                List<CsaladiHaz> csaladiHazak = new List<CsaladiHaz>();
                foreach (var aktIngatlan in listIngatlanok) {
                    if (aktIngatlan is CsaladiHaz) {
                        CsaladiHaz csHaz = aktIngatlan as CsaladiHaz;
                        csaladiHazak.Add(csHaz);
                    }
                }
                return csaladiHazak;
            }
        }
        public void AddIngatlan(Ingatlan ujIngatlan) {
            if (!listIngatlanok.Contains(ujIngatlan)) {
                listIngatlanok.Add(ujIngatlan);
            } else {
                throw new Exception($"[HIBA] A(z) {ujIngatlan.HelyrajziSzam} helyrajziszámon lévő ingatlan már benne van a listában.");
            }
        }
    }
}
