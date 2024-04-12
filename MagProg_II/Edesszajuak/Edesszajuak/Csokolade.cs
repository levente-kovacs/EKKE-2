using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edesszajuak
{
    internal class Csokolade : Edesseg
    {
        private float kakaoTartalom;
        public float KakaoTartalom {
            get => kakaoTartalom;
            private set
            {
                if (kakaoTartalom < 0 || kakaoTartalom > 100)
                {
                    throw new Exception("[HIBA] A kakaó tartalom 0 és 100 közé kell essen.");
                }
                kakaoTartalom = value;
            }
        }

        public CsokoladeFajta Fajta { get; set; }

        public Csokolade(string nev, float cukorTartalom, float tomeg, float kakaoTartalom, CsokoladeFajta fajta) : base(nev, cukorTartalom, tomeg)
        {
            KakaoTartalom = kakaoTartalom;
            Fajta = fajta;
        }

        public override void Megeszem(float elfogyasztottSzazalek)
        {
            if (elfogyasztottSzazalek <= 50)
            {
                base.Megeszem(elfogyasztottSzazalek * 2);
            }
            else
            {
                base.Megeszem(100);
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is Csokolade)
            {
                Csokolade csokolade = obj as Csokolade;
                return this.kakaoTartalom <= csokolade.kakaoTartalom && this.Fajta == csokolade.Fajta;
            }
            return false;
        }


    }
}
