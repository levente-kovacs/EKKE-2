using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzallitoDLL
{
    internal class SzallitoVallalat
    {
        private List<KuldemenyAlap> kuldemenyAlapok = new List<KuldemenyAlap>();

        public void Rogzit(KuldemenyAlap kuldemenyAlap)
        {
            if (!kuldemenyAlapok.Contains(kuldemenyAlap))
                kuldemenyAlapok.Add(kuldemenyAlap);
            else
                throw new ArgumentException($"A {kuldemenyAlap.Cim} küldemény alap már benne van a listában.");
            kuldemenyAlapok.Sort();
        }

        public List<Kuldemeny> EunKivuliKuldemenyek
        {
            get => kuldemenyAlapok.Where(k => k is Kuldemeny)
                                  .Where(k => !(k as Kuldemeny).Cim.EuTagallam)
                                  .Select(K => K.Clone())
                                  .Select(k => k as Kuldemeny)
                                  .OrderBy(k => k.Cim.OrszagKod)
                                  .ThenBy(k => k.Cim.Varos)
                                  .ThenByDescending(k => k.Terfogat)
                                  .ToList();
        }
    }
}
