namespace Konyvespolc {
    internal class KonyvespolcMain {
        static void Main(string[] args) {
            KonyvesPolc konyvesPolc = new KonyvesPolc();
            konyvesPolc.AddBook(new Konyv("Barton Erika", "Bogyó és babóca", 2022, 1200, KonyvMufaj.Mese));
            konyvesPolc.AddBook(new Konyv("Barton Erika", "Bigyó és kabóca", 2995));
            konyvesPolc.AddBook(new Konyv("Tom Thomas", "Én, a gőzmozdony", 9995));
            konyvesPolc.AddBook(new Konyv("Rimán János", "Matemiatikai Analízis feladatgyűjtemény II. kötet", 2002, 1500, KonyvMufaj.Regeny));
            konyvesPolc.AddBook(new Konyv("Liptai Kálmán", "Analízis feladatgyűjtemény", 2000));
            try {
                konyvesPolc.AddBook(new Konyv("Rimán János", "Matemiatikai Analízis feladatgyűjtemény I. kötet", 2002, 1352, KonyvMufaj.Regeny));
            } catch (Exception e) { //a nem megfelelő ár miatt elkapjuk a kivételt
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            Console.WriteLine($"Könyvespolcon lévő könyvek össz értéke: {konyvesPolc.TotalPrice}");
            foreach (var item in konyvesPolc.Search("Barton Erika")) {
                Console.WriteLine(item);
            }
            foreach (var item in konyvesPolc.Search("Liptai Kálmán")) {
                Console.WriteLine(item);
            }
        }
    }
}
