namespace Jedik {
    internal class Jedik {
        static void Main(string[] args) {
            Rend LajosEsAHaverok = new Rend();
            StreamReader sr = new StreamReader("rend.txt");
            while (!sr.EndOfStream) {
                string sor = sr.ReadLine();
                string[] adatok =  sor.Split(";");

                if (adatok.Length == 2) {
                    LajosEsAHaverok.AddJedi(adatok[0], int.Parse(adatok[1]));
                } else if (adatok.Length == 4) {
                    LajosEsAHaverok.AddJedi(adatok[0], int.Parse(adatok[1]), (KardSzinek)Enum.Parse(typeof(KardSzinek), adatok[2]), bool.Parse(adatok[3]));
                } else {
                    throw new Exception("Helytelen hosszúságú sor.");
                }
            }
            sr.Close();

            Console.WriteLine($"Legnagyobb midimodimidátumiszámú dzsetti mester: {LajosEsAHaverok.Legnagyobbjedi.Nev}");
            Console.WriteLine($"Renátó midiizé száma: {LajosEsAHaverok["Renátó"].MidiklorianokSzama}");
            Console.WriteLine($"Átlagos midiizé szám: {LajosEsAHaverok.MidiklorianAtlag:n3}");  //double értékhez a :n3 ezres tagolás egészre, tizedes 3 karakterre csonkolva, csak kiírásnál formáz, értéket nem
            foreach (var jedi in LajosEsAHaverok.JedikAdottKarddal(KardSzinek.SARGA)) {
                Console.WriteLine(jedi.Nev);
            }
            Console.WriteLine();
            Console.WriteLine(LajosEsAHaverok.Legnagyobbjedi);
            Console.WriteLine(LajosEsAHaverok["Renátó"]);
            foreach (var jedi in LajosEsAHaverok.JedikAdottKarddal(KardSzinek.SARGA)) {
                Console.WriteLine(jedi);
            }
        }
    }
}
