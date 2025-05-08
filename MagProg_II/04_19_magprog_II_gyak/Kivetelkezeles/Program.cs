using Kivetelkezeles.comonents;

namespace Kivetelkezeles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Urhajo u = new Urhajo("u", 100, UrhajoKategoria.Korvett);
            u.KomponensFelszerel(new Reaktor(100));
            u.KomponensFelszerel(new Hajtomu(100));

            try
            {
                u.Leallit();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

        }
    }
}