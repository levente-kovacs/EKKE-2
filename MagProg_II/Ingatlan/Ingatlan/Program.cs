using System;

namespace Ingatlan {
    internal class Program {
        static void Main(string[] args) {
            //try {
            //    Ingatlan test01 = new Ingatlan("12345", 10, 15, Allapot.Korszerusitett);
            //    Console.WriteLine(test01.ToString());
            //    Console.WriteLine(test01);
            //    test01.Vetelar();
            //} catch (Exception e) {
            //    Console.WriteLine(e.Message);
            //}
            //try {
            //    Ingatlan test02 = new Ingatlan("123/45/", 10, 15, Allapot.Korszerusitett);
            //    Console.WriteLine(test02);
            //} catch (Exception e) {
            //    Console.WriteLine(e.Message);
            //}
            //try {
            //    Ingatlan test02 = new Ingatlan("123/45", 10, 15, Allapot.Korszerusitett);
            //    Console.WriteLine(test02);
            //} catch (Exception e) {
            //    Console.WriteLine(e.Message);
            //}
            //try {
            //    CsaladiHaz csTest01 = new CsaladiHaz("123/45", 10, 15, Allapot.Korszerusitett, 50, 50, 2);
            //    Console.WriteLine(csTest01);
            //} catch (Exception e) {
            //    Console.WriteLine(e.Message);
            //}
            
            IngatlanIroda ingatlanIroda = new IngatlanIroda();

            StreamReader sr = new StreamReader("ingatlanok.txt");
            while (!sr.EndOfStream) {
                //string[] adatok = sr.ReadLine().Split(';');
                string sor = sr.ReadLine();
                string[] adatok = sor.Split(';');
                try {
                    byte iSzel, iHossz;
                    if (!byte.TryParse(adatok[2], out iSzel)) {
                        throw new Exception($"[HIBA] A harmadik érték [{adatok[4]}] nem konvertálható számmá.");
                    }
                    if (!byte.TryParse(adatok[3], out iHossz)) {
                        throw new Exception($"[HIBA] A negyedik érték [{adatok[4]}] nem konvertálható számmá.");
                    }
                    iSzel = byte.Parse(adatok[2]);
                    iHossz = byte.Parse(adatok[3]);

                    if (adatok[0] == "I") {
                        ingatlanIroda.AddIngatlan(new Ingatlan(adatok[1], iSzel, iHossz, (Allapot)Enum.Parse(typeof(Allapot), adatok[4])));
                    } else if (adatok[0] == "CS") {
                        ingatlanIroda.AddIngatlan(new CsaladiHaz(adatok[1], iSzel, iHossz, (Allapot)Enum.Parse(typeof(Allapot), adatok[4]), byte.Parse(adatok[5]), byte.Parse(adatok[6]), byte.Parse(adatok[7])));
                    }
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
