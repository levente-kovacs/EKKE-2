using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2___App
{
    internal class Program
    {
        //static void KuldemenyekRogzitese(SzallitoVallalat vallalat, string file)
        //{
        //    StreamReader sr = new StreamReader(file);
        //    while (!sr.EndOfStream)
        //    {
        //        string sor = sr.ReadLine();
        //        string[] adatok = sor.Split(';');
        //        Kuldemeny ujKuldemeny = new Kuldemeny(int.Parse(adatok[0]), int.Parse(adatok[1]), int.Parse(adatok[2]),
        //                                              double.Parse(adatok[3]),
        //                                              adatok[4], adatok[5],
        //                                              (BiztositasTipus)Enum.Parse(typeof(BiztositasTipus), adatok[6]));
        //        vallalat.Rogzit(ujKuldemeny);
        //    }
        //}

        static void Main(string[] args)
        {
            //SzallitoVallalat vallalat = new SzallitoVallalat();
            //KuldemenyekRogzitese(vallalat, "kuldemenyek.csv");

            //foreach (KuldemenyAlap kuldemeny in vallalat)
            //{
            //    Console.WriteLine(kuldemeny);
            //}

            //Console.ReadLine();
        }
    }
}
