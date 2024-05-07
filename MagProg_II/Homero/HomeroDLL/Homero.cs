using HomeroDLL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace HomeroDLL
{
    public class Homero : Szenzor, IHomero
    {
        private static Random rnd = new Random();

        private int alsoHatar;
        public int AlsoHatar
        {
            get => alsoHatar;
            private set
            {
                if (value < -60)
                    throw new AlacsonyAlsoHatarException();
                alsoHatar = value;
            }
        }

        public int FelsoHatar { get; private set; }

        private bool aktiv;
        public override bool Aktiv
        {
            get => aktiv;
        }

        public void SetAktiv(bool value)
        {
            aktiv = value;
        }

        public Homero(int x, int y, int alsoHatar, int felsoHatar) : base(new Pozicio(x, y))
        {
            HatarokatBeallit(alsoHatar, felsoHatar);
            SetAktiv(true);
        }

        public override object Clone()
        {
            return this.MemberwiseClone(); 
        }

        public void HatarokatBeallit(int alsoHatar, int felsoHatar)
        {
            this.AlsoHatar = alsoHatar;
            FelsoHatar = felsoHatar;
        }

        public double HomersekletetMer()
        {
            if (!Aktiv)
                throw new SzenzorInaktivException();
            return Math.Floor((rnd.NextDouble() * (FelsoHatar - alsoHatar) + alsoHatar) * 100) / 100;
        }

        protected override void Adatkuldes()
        {
            Console.WriteLine($"Hőmérséklet a(z) ({alsoHatar};{FelsoHatar}) pozíción {DateTime.Now} időpontban: {HomersekletetMer()}°C");
        }

        public override string ToString()
        {
            return string.Format("Hőmérő: {0}, A:{1} - F{2}",
                base.ToString(), AlsoHatar, FelsoHatar);
        }
    }
}
