using HomeroDLL;
using HomeroDLL.Exceptions;

namespace Homero
{
    internal class Program
    {
        static Random rnd = new Random();

        static void TelepitSzenzorHalozat(string input, SzenzorHalozat halozat)
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(input);
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    string[] adatok = sor.Split(';');
                    HomeroDLL.Homero homero = null;
                    try
                    {
                        homero = new HomeroDLL.Homero(int.Parse(adatok[1]), int.Parse(adatok[2]),
                                                   int.Parse(adatok[3]), int.Parse(adatok[4]));
                        if (rnd.NextDouble() < 0.3)
                            homero.SetAktiv(false);
                        halozat.Telepit(homero);
                    }
                    catch (AlacsonyAlsoHatarException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (SzenzorInaktivException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"A megadott file ({input}) nem létezik. - {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sr?.Close();
            }
        }

        static int getXKoordinata(HomeroDLL.Homero homero)
        {
            return homero.Pozicio.x;
        }


        static void Main(string[] args)
        {
            SzenzorHalozat halozat = new SzenzorHalozat();
            TelepitSzenzorHalozat("szenzorok.csv", halozat);

            foreach (Szenzor szenzor in halozat)
            {
                Console.WriteLine(szenzor);
            }

            Console.WriteLine("\nAktív szenzorok:");
            foreach (Szenzor aktivSzenzor in halozat.AktivSzenzorok)
            {
                Console.WriteLine(aktivSzenzor);
            }

            Console.WriteLine($"\nAz aktív hőmérők x koordinátáinak átlaga: {halozat.AktivAtlag(getXKoordinata)}");

            Console.ReadLine();
        }
    }
}