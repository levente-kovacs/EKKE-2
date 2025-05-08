namespace Delegates
{
    internal class Program
    {
        delegate bool Dontes(Auto auto);
        
        static void Main(string[] args)
        {
            List<Auto> autok = new List<Auto>()
            {
                new Auto(3, Szin.piros, "Opel", Tipus.szedan, 1992),
                new Auto(3, Szin.kek, "BMW", Tipus.kombi, 2002),
                new Auto(5, Szin.zold, "BMW", Tipus.kombi, 2004),
                new Auto(5, Szin.barna, "Merced", Tipus.szedan, 1992),
            };

            //static bool BMWE(Auto auto)
            //{
            //    if (auto.Gyarto == "BMW") return true;
            //    return false;
            //}

            Dontes m1 = (Auto auto) => auto.Gyarto == "BMW";
            Dontes m2 = (Auto auto) => auto.AjtokSzama == 5;
            Dontes m3 = (Auto auto) => auto.Evjarat == 1990;
            Dontes m4 = (Auto auto) => auto.Tipus == Tipus.kombi;


            static bool VanE(List<Auto> autok, Dontes dontes)
            {
                foreach (Auto auto in autok)
                {
                    if (dontes(auto)) return true;
                }
                return false;
            }

            Console.WriteLine(VanE(autok, m4));

            List<Auto> ujAutok = autok.FindAll((Auto a) => (a.Szin == Szin.zold || a.Szin == Szin.kek) && a.Gyarto == "BMW");

            Console.ReadKey();
        }
    }
}