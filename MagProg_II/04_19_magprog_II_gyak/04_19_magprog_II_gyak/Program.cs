using _04_19_magprog_II_gyak.Jatekosok;

namespace _04_19_magprog_II_gyak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SzamKitalaloJatek j = new SzamKitalaloJatek(100, 200);
            j.VersenyzoFelvesz(new EmberiJatekos());
            // j.VersenyzoFelvesz(new GepiJatekosok()); // az abstract nem példűnyosítható !!
            j.VersenyzoFelvesz(new VeletlenTippelo());
            j.Jatek();


        }
    }
}