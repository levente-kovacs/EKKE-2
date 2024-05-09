using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Diakok
{
    internal class Diak
    {
        private static Random rnd = new Random();
        private static List<string> generaltNeptunkodok = new List<string>();
        private static int ID = 1;

        public Diak(string nev, string szulDatum) : this(nev, szulDatum, Gender.Egyeb, 1.0)
        {            
        }
        public Diak(string nev, string szulDatum, Gender gender, double atlag)
        {
            this.id = ID; ID++;
            this.neptunkod = GetEgyediNeptunkod();
            generaltNeptunkodok.Add(this.neptunkod);
            this.Nev = nev;
            this.szulDatum = DateTime.Parse(szulDatum);
            this.Gender = gender;
            this.SetAtlag(atlag);
        }

        private int id;
        private string neptunkod; //pontosan 6 hosszú, nem tartalmazhat speciális karaktereket, nem kezdődhet számmal, akárhgyan adták meg, mindig csupa nagybetűvel mensük el
        private string nev; //legalább egy space, minden rész szöveg legalább 2 karakter hosszú
        public DateTime szulDatum; //18 évnél fiatalabb hallgatót nem regisztrálunk, az életkort maximlizáljuk 100 évben
        
        public Gender Gender { get; set; }
        
        private double atlag;

        private bool neptunkodMegadva = false;
        public string Neptunkod
        {
            set
            {
                if (neptunkodMegadva)
                    throw new Exception("A neptunkódot csak egyszer lehet megadni!");

                neptunkod = value;
                neptunkodMegadva = true;
            }
            get
            {
                return neptunkod;
            }
        }

        private int nevMegadva = 0;
        public string Nev
        {
            private set
            {
                if (nevMegadva >= 5)
                    throw new Exception("A nevet csak 5x lehet változatni!");

                if (!value.Contains(' '))
                    throw new Exception("A névnek legalább egy space-t tartalmaznia kell!");
                string[] darabok = value.Split(' ');
                foreach (string nevResz in darabok)
                {
                    if (nevResz.Length < 2)
                        throw new Exception($"A név egyes része nem lehetnek 2 karakternél rövidebbek. Input: {value}");
                }

                nev = value;
                nevMegadva++;
            }
            get
            {
                return nev;
            }
        }

        public void SetAtlag(double value)
        {
            if (value < 1.0)
                throw new Exception($"Az átlag nem lehet kisebb, mint 1! A diák neve {nev} kapott érték: {value}");
            if (value > 5.0)
                throw new Exception($"Az átlag nem lehet nagyobb, mitn 5! A diák neve {nev} kapott érték: {value}");

            atlag = value;
        }
        public double GetAtlag()
        {
            return atlag;
        }

        private static string GetEgyediNeptunkod()
        {
            string nk;
            do
            {
                nk = GetNeptunkod();
            } while (generaltNeptunkodok.Contains(nk));
            return nk;
        }
        private static string GetNeptunkod()
        {
            string abc = "QWERTZUIOPASDFGHJKLYXCVBNM";
            string nk = string.Empty;
            for (int i = 0; i < 6; i++)
            {
                nk += abc[rnd.Next(abc.Length)];
            }
            return nk;
        }

        public override string ToString()
        {
            string szoveg = string.Empty;
            szoveg += $"Id: {id}\n";
            szoveg += $"Név: {nev}\n";
            szoveg += $"Neptunkód: {neptunkod}\n";
            szoveg += $"Születési dátum: {szulDatum.ToString("yyyy.MM.dd (dddd)")}\n";
            szoveg += $"Neme: {gender}\n";
            szoveg += $"Átlag: {atlag}\n";
            return szoveg;
        }
    }
}
