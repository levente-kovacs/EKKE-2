using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edesszajuak
{
    internal class Edesseg
    {
        private string nev;
        public string Nev
        {
            get => nev;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("[HIBA] Név üres.");
                }
                nev = value;
            }
        }

        private float cukorTartalom;
        public float CukerTartalom
        {
            get => cukorTartalom;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception("[HIBA] A cukor tartalomnak 0 és 100 közé kell esnie.");
                }
                cukorTartalom = value;
            }
        }

        public bool Diabetikus {
            get => cukorTartalom < 0.5;
        }

        private float tomeg;
        public float Tomeg {
            get => tomeg;
            private set
            {
                if (value < 0)
                {
                    throw new Exception("[HIBA] A tömeg nem lehet negatív.");
                }
                tomeg = value;
            }
        }

        public Edesseg(string nev, float cukorTartalom, float tomeg)
        {
            Nev = nev;
            CukerTartalom = cukorTartalom;
            Tomeg = tomeg;
        }

        public Edesseg(string nev,float tomeg) : this(nev, 0.4f, tomeg)
        {  }

        public virtual void Megeszem(float elfogyasztottSzazalek)
        {
            if (elfogyasztottSzazalek < 0 || elfogyasztottSzazalek > 100)
            {
                throw new Exception("[HIBA] Az elfogyasztott százalék 0 és 100 közé kell essen.");
            }
            tomeg *= (100 - elfogyasztottSzazalek) / 100;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Edesseg)
            {
                Edesseg edesseg = obj as Edesseg;
                return this.nev == edesseg.nev && this.cukorTartalom == edesseg.cukorTartalom && this.tomeg > edesseg.tomeg;
            }
            return false;
        }

        public override string? ToString()
        {
            return $"Név:\t\t{nev}\nCukortartalom:\t{cukorTartalom}\nDiabetikus:\t{(Diabetikus ? "Diabetikus" : "Nem diabetikus")}\nTömeg:\t\t{tomeg}";
        }
    }
}
