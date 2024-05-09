using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using _07_KonyvesboltDLL;

namespace _7_KonyvesboltApp
{
    internal class Program
    {
        static void Info(string szoveg)
        {
            Console.WriteLine(szoveg);
        }
        static void Warning(string szoveg)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(szoveg);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static void Error(string szoveg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(szoveg);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void Beolvas(string fileNev, Konyvesbolt bolt)
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(fileNev);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    string[] adatok = sor.Split(';');

                    try
                    {
                        Konyv ujKonyv = new Konyv(adatok[0],
                                                  adatok[1],
                                                  int.Parse(adatok[2]),
                                                  adatok[4] == "igen",
                                                  (Mufaj)Enum.Parse(typeof(Mufaj), adatok[3]));
                        bolt.AddKonyv(ujKonyv);
                        Info($"Beolvasva: {sor}");
                    }
                    catch (AlacsonyArException)
                    {
                        Konyv ujKonyv = new Konyv(adatok[0],
                                                  adatok[1],
                                                  500,
                                                  adatok[4] == "igen",
                                                  (Mufaj)Enum.Parse(typeof(Mufaj), adatok[3]));
                        bolt.AddKonyv(ujKonyv);
                        Warning("Figyelmeztetés: " + sor + " --- esetén az árat 500 Ft-ra állítottuk.");
                    }
                    catch (MagasArException ex)
                    {
                        Konyv ujKonyv = new Konyv(adatok[0],
                                                  adatok[1],
                                                  50000,
                                                  adatok[4] == "igen",
                                                  (Mufaj)Enum.Parse(typeof(Mufaj), adatok[3]));
                        bolt.AddKonyv(ujKonyv);
                        Warning($"Figyelmeztetés: {sor} --- esetén az árat ({ex.TulMagasAr}) 50000 Ft-ra állítottuk.");
                    }
                    catch (ArgumentException)
                    {
                        Konyv ujKonyv = new Konyv(adatok[0],
                                                  adatok[1],
                                                  int.Parse(adatok[2]),
                                                  adatok[4] == "igen",
                                                  Mufaj.NemDefinialt);
                        bolt.AddKonyv(ujKonyv);
                        Warning("Figyelmeztetés: " + sor + " --- esetén a műfajt nem sikerült megállapítani.");
                    }
                    catch (FormatException)
                    {
                        Konyv ujKonyv = new Konyv(adatok[0],
                                                  adatok[1],
                                                  adatok[4] == "igen",
                                                  (Mufaj)Enum.Parse(typeof(Mufaj), adatok[3]));
                        bolt.AddKonyv(ujKonyv);
                        Warning("Figyelmeztetés: " + sor + " --- esetén az árat nem sikerült megadni.");
                    }
                    catch (Exception ex)
                    {
                        Error("Hiba: " + ex.Message);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Error("Hiba: a fájl nem található.");
                Error("Fájlnév: " + ex.FileName);
            }
            catch (Exception ex)
            {
                Error("Hiba: " + ex.Message);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }

            Console.WriteLine("A fájl feldolgozása megtörtént.");
            Console.ReadLine();
            Console.Clear();
        }

        static double KonvAra(Konyv konyv)
        {
            return konyv.Ar;
        }
        static double KonvHossza(Konyv konyv)
        {
            return konyv.Oldalszam;
        }
        static void Main(string[] args)
        {
            Konyvesbolt bolt = new Konyvesbolt();
            Beolvas("konyvek.csv", bolt);

            //foreach (Konyv konyv in bolt.Konyvek)
            //{
            //    Console.WriteLine(konyv);
            //}

            //Console.ReadLine();
            //Console.Clear();
            //Console.WriteLine("A 2000 és 3000 Ft közé eső nem ebook sci-fi könyvek" +
            //    " szerző szerint növekvő, majd cím szerint csökkenő sorrendben:\n");
            //List<Konyv> feladat1 = bolt.Konyvek.Where(k => k.Ar >= 2000 && k.Ar <= 4000)
            //                                   .Where(k => k.Mufaj == Mufaj.SciFi)
            //                                   .Where(k => !k.EKonyv)
            //                                   .OrderBy(k => k.Szerzo)
            //                                   .ThenByDescending(k => k.Cim)
            //                                   .ToList();
            //foreach (Konyv konyv in feladat1)
            //{
            //    Console.WriteLine(konyv);
            //}

            //Console.ReadLine();
            //Console.Clear();
            //Console.WriteLine("A nem ekönyvek szerzőinek a nevei, mindegyik pontosan egyszer kiválogatva, névsorrendben:\n");

            //List<string> szerzok = bolt.Konyvek.Where(k => !k.EKonyv)
            //                                   .OrderBy(k => k.Szerzo)
            //                                   .Select(k => k.Szerzo)
            //                                   .Distinct()
            //                                   .ToList();
            //foreach (string szerzo in szerzok)
            //{
            //    Console.WriteLine(szerzo);
            //}

            //Console.ReadLine();
            //Console.Clear();
            //Console.Write("A Cixin Liu által írt könyvek átlagos ára: ");
            //double atlag = bolt.Konyvek.Where(k => k.Szerzo == "Cixin Liu")
            //                           .Where(k => k.Ar != 0)
            //                           .Average(k => k.Ar);
            //Console.WriteLine(atlag);
            //Console.Write("A Cixin Liu által írt könyvek összértéke: ");
            //double osszeg = bolt.Konyvek.Where(k => k.Szerzo == "Cixin Liu")
            //                           .Where(k => k.Ar != 0)
            //                           .Sum(k => k.Ar);
            //Console.WriteLine(osszeg);

            //Console.WriteLine("A rendszerben {0} olyan könyv van, amit Dan Simmons írt.",
            //    bolt.Konyvek.Count(k => k.Szerzo == "Dan Simmons"));
            //Console.WriteLine("A rendszerben {0} olyan könyv, amit Ken Liu írt.",
            //    bolt.Konyvek.Any(k => k.Szerzo == "Ken Liu") ? "van" : "nincs");
            //Console.WriteLine("A rendszerben {0} olyan könyv, amit Alastair Reynolds írt.",
            //    bolt.Konyvek.Any(k => k.Szerzo == "Alastair Reynolds") ? "van" : "nincs");

            //int minAr = bolt.Konyvek.Where(k => k.Ar != 0).Min(k => k.Ar);
            //Konyv legolcsobb = bolt.Konyvek.Where(k => k.Ar == minAr).FirstOrDefault();
            //Console.WriteLine("A legolcsóbb könyv: " + legolcsobb);

            //Console.ReadLine();
            //Console.Clear();
            //Console.Write("A három legdrágább könyv: \n");
            //foreach (Konyv konyv in bolt.Konyvek.OrderByDescending(k => k.Ar).Take(3))
            //{
            //    Console.WriteLine(konyv);
            //}

            double konyvekOsszerteke = bolt.Osszeg(KonvAra);
            Console.WriteLine("A könyvek összértéke: " + konyvekOsszerteke);
            Console.WriteLine("A könyvek összhossza: " + bolt.Osszeg(KonvHossza));
            Console.WriteLine("A könyvek címeinek a hossza: " + bolt.Osszeg(k => k.Cim.Length));

            Console.WriteLine("\nA 4000 Ft alatti nem ekönyvek:");
            foreach (Konyv konyv in bolt.Kivalogat(k => !k.EKonyv && k.Ar < 4000))
            {
                Console.WriteLine(konyv);
            }

            Console.ReadLine();
        }
    }
}
