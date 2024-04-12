/*
File olvasáshoz példa beállítás:
Solution Explorernél Add new item --> txt file, ebbe mehet a tartalom
Solution Explorernél a txt fájl property-jében állítsuk át a Copy to output directory-t Copy if newer-re
 */
namespace Orszagok {
    internal class OrszagokMain {
        static void Main(string[] args) {
            Terkep terkep = new Terkep();

            StreamReader sr = new StreamReader("countries.txt");
            while (!sr.EndOfStream) {
                string[] sor = sr.ReadLine().Split(';');
                try {
                    switch (sor.Count()) {
                        case 3:     //3 adat esetén Ország, a 
                            terkep.OrszagHozzaadasa(new Orszag(sor[0], uint.Parse(sor[1]), float.Parse(sor[2])));
                            break;
                        case 4:     //4 adat esetén AU tagország vagy olyan NATO tagország ahol nincs hadászati ráfordítás (a txt-ben nincs ilyen rekord alapból)
                            if (Enum.IsDefined(typeof(enumNatoTagTipus), sor[3])) {     //Ha a sor[3] értéke benne van az enumNatoTagTipus-ban akkor a négy értéket fogadó NatoTagorszag konstruktort hívjuk meg
                                terkep.OrszagHozzaadasa(new NatoTagorszag(sor[0], uint.Parse(sor[1]), float.Parse(sor[2]), (enumNatoTagTipus)Enum.Parse(typeof(enumNatoTagTipus), sor[3]))); 
                            } else {    //ellenkező esetben meg az AUTagorszag konstruktort
                                terkep.OrszagHozzaadasa(new AUTagorszag(sor[0], uint.Parse(sor[1]), float.Parse(sor[2]), (enumAUHivatalosNyelv)Enum.Parse(typeof(enumAUHivatalosNyelv), sor[3])));
                            }
                            break;
                        case 5:     //5 adat esetén NATO tagország, de trükkös lehet, a txt-ben az enum és a float nem abban a sorrendben van, ahogy a feladattal haladtunk...
                            terkep.OrszagHozzaadasa(new NatoTagorszag(sor[0], uint.Parse(sor[1]), float.Parse(sor[2]), float.Parse(sor[4]), (enumNatoTagTipus)Enum.Parse(typeof(enumNatoTagTipus), sor[3])));
                            break;
                        default:
                            break;
                    }
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }
            sr.Close();

            Console.WriteLine($"Legnépesebb ország: {terkep.LegnepesebbOrszag}");
            Console.WriteLine();
            Console.WriteLine($"Átlagos GDP: {terkep.AtlagosGDP:n2} millió USD");
            Console.WriteLine();
            Console.WriteLine($"Legnépesebb arab nyelvű ország: {terkep.legnepesebbAUTagorszagAdottNyelvvel(enumAUHivatalosNyelv.Arabic)}");
            Console.WriteLine("\nNATO tagországok legalább 1,5% harcászati hozzájárulással:");
            foreach (var orszag in terkep.teljesNatoTagorszagok(1.5f)) {
                Console.WriteLine("\t" + orszag);
            }
            Console.WriteLine();
            foreach (var orszag in terkep.osszesOrszag) {
                Console.WriteLine(orszag);
            }
            Console.WriteLine();
            Console.WriteLine("GDP növelés");
            foreach (var orszag in terkep.osszesOrszag) {
                orszag.gdpAllito(1.4f);
                Console.WriteLine(orszag);
            }
            Console.WriteLine();
            Console.WriteLine("GDP csökkentés");
            foreach (var orszag in terkep.osszesOrszag) {
                orszag.gdpAllito(-0.6f);
                Console.WriteLine(orszag);
            }
        }
    }
}
