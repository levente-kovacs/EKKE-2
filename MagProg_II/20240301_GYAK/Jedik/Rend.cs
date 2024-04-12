using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Készítsen jedi lovagok tárolására alkalmas konténerosztályt Rend néven az alábbiak implementálásával! 
• Jedik: jedi lovagok tárolására alkalmas lista, megfelelő védelemmel ellátva 
• AddJedi(): publikus metódus. Paraméterben bekéri a nevet és a midiklorián számot, majd ezek alapján 
elkészít egy jedi példányt és elhelyezi azt a listában. Ha a rend már tartalmaz ilyen nevű jedit, dobjon 
kivételt! 
• AddJedi(): publikus metódus. Paraméterben bekéri a jedi minden adatát, majd ezek alapján elkészít 
egy jedi példányt és elhelyezi azt a listában. Ha a rend már tartalmaz ilyen nevű jedit, dobjon kivételt! 
• indexer: bekér egy nevet és visszaadja a listából azt a jedi példányt, akit így hívnak. Ha nincs ilyen 
nevű jedi, akkor dobjon kivételt! 
• LegnagyobbJedi: csak olvasható property, mely visszaadja a legnagyobb midikloriánszámmal 
rendelkező jedi mester példányt. 
• MidiklorianAtlag: csak olvasható property. Kiszámítja a rend tagjainak átlagos midiklorián számát. 
• JedikAdottKarddal(): publikus metódus. Paraméterben kér egy kardszínt. Listába gyűjti és visszatér a 
kapott színnel rendelkező jedikkel. 
 */
namespace Jedik { 
    internal class Rend {
        private List<Jedi> Jedik = new List<Jedi>();
        public void AddJedi(string jediNeve, int jediMidiSzam) {
            Jedi ujJedi = new Jedi(jediNeve, jediMidiSzam);
            JeditHozzaad(ujJedi);
        }
        public void AddJedi(string jediNeve, int jediMidiSzam, KardSzinek jediKardSzine, bool jediMester) {
            Jedi ujJedi = new Jedi(jediNeve, jediMidiSzam, jediKardSzine, jediMester);
            JeditHozzaad(ujJedi);
        }
        private void JeditHozzaad(Jedi ujJedi) {
            if (Jedik.Any(regiJedi => regiJedi.Nev == ujJedi.Nev)) {  //foreach helyett lambda, nem kell forech, ha benne van a név akkor kivételt dob
                throw new Exception("[HIBA] Ilyen Jedit már katalogizáltunk.");
            }
            Jedik.Add(ujJedi);
        }
        public Jedi Legnagyobbjedi {    //származtatott property, nincs mögöttes mező tárolásra
            get {
                //TO-DO házi: csak mesterekre vizsgálni
                //Jedi maxJedi = Jedik[0];
                //foreach (var jedi in Jedik) {
                //    if (jedi.Mester && jedi.MidiklorianokSzama > maxJedi.MidiklorianokSzama) {
                //        maxJedi = jedi;
                //    }
                //}
                //return maxJedi;

                //a Jedik listából kikeressük az első elemet ahol mester és a legtöbb midiizé számmal rendelkezik
                //Viszont hibát dob az, ha egy nem mesternek több a midiizé száma, ezért a legtöbb midiizészámot egy olyan listából szedjük, ahova Where-el összeszedtük az összes mestert
                return Jedik.First(jedi => jedi.Mester && jedi.MidiklorianokSzama == Jedik.Where(jediMester => jediMester.Mester).ToList().Max(jediMidi => jediMidi.MidiklorianokSzama));
            }
        }
        public double MidiklorianAtlag {
            get {
                return Jedik.Average(jedi => jedi.MidiklorianokSzama);
            }
        }
        public List<Jedi> JedikAdottKarddal(KardSzinek kardSzin) {
            //List<Jedi> listJediAdottKarddal = new List<Jedi>();
            //foreach (var jedi in Jedik) {
            //    if (jedi.KardSzine == kardSzin) {
            //        listJediAdottKarddal.Add(jedi);
            //    }
            //}
            //return listJediAdottKarddal;
            return Jedik.Where(jedi => jedi.KardSzine == kardSzin).ToList();    //Lambda szűrésre, kell a ToList() a végére
        }
        //indexer (ez property)
        //indexer fix neve a this, paraméterek [] között
        public Jedi this[string nev] {
            get {
                foreach (var jedi in Jedik) {
                    if (jedi.Nev == nev) {
                        return jedi;
                    }
                }
                throw new Exception($"Nincs {nev} nevű jedi a rendben.");
            }
        }
    }
}
