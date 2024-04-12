using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ingatlan {
    internal class Ingatlan {
        private string helyrajziSzam;
        public string HelyrajziSzam {
            get => helyrajziSzam;
            private set {
                //if (value == null || value == "") {
                if (string.IsNullOrEmpty(value)) {
                    throw new Exception("[HIBA] A helyrajziszám vagy null vagy üres.");
                }
                //if (!Regex.IsMatch(value, @"^[1-9]\d*(/\d+)*$")) {
                for (int i = 0; i < value.Length; i++) {
                    if (i == 0 && (value[0] == '0' || value[0] == '/')) {
                        throw new Exception($"{value[i]}");
                    }
                    if (i == value.Length - 1 && (value[value.Length - 1] == '/')) {
                        throw new Exception($"{value[i]}");
                    }
                    if (!char.IsDigit(value[i]) && value[i] != '/') {
                        throw new Exception($"{value[i]}");
                    }
                }
                helyrajziSzam = value;
            }
        }
        bool voltSzelessegMegadva = false;
        private byte szelesseg;
        public byte Szelesseg {
            get { return szelesseg; }
            private set {
                if (voltSzelessegMegadva) {
                    throw new Exception("");
                }
                if (value < 4 || value > 20) {
                    throw new Exception("");
                }
                szelesseg = value;
                voltSzelessegMegadva = true;
            }
        }
        bool voltHosszMegadva = false;
        private byte hosszusag;
        public byte Hosszusag {
            get { return hosszusag; }
            private set {
                if (voltHosszMegadva) {
                    throw new Exception("");
                }
                if (value < 4 || value > 20) {
                    throw new Exception("Sok a hossz");
                }
                hosszusag = value;
                voltHosszMegadva = true;
            }
        }
        public Allapot Allapot { get; set; }
        public virtual ushort Alapterulet {
            get => (ushort)(szelesseg * hosszusag);
        }
        public Ingatlan(string helyrajziSzam, byte szelesseg, byte hosszusag, Allapot allapot) {
            HelyrajziSzam = helyrajziSzam;
            Szelesseg = szelesseg;
            Hosszusag = hosszusag;
            Allapot = allapot;
        }
        public Ingatlan(string helyrajziSzam, byte szelesseg, byte hosszusag) : this(helyrajziSzam, szelesseg, hosszusag, Allapot.Ujepitesu) {
        }
        public virtual uint Vetelar() {
            int nmAr = 0;
            switch (Allapot) {
                case Allapot.Ujepitesu:
                    nmAr = 600000;
                    break;
                case Allapot.Korszerusitett:
                    nmAr = 500000;
                    break;
                case Allapot.Felujitott:
                    nmAr = 450000;
                    break;
                case Allapot.Felujitando:
                    nmAr = 300000;
                    break;
                default:
                    throw new Exception("[HIBA] Nem kezelt enumAllapot az Ingatlan Vetalar metódusában.");
            }
            return (uint)(Alapterulet * nmAr);
        }
        public override string ToString() {
            return $"Az ingatlan:\n\t- helyrajziszáma: {helyrajziSzam}\n\t- szélessége: {szelesseg} m; hossza: {hosszusag} m; alapterülete: {Alapterulet} nm\n\t- állapota: {Allapot}\n\t- vételára: {Vetelar():n0} Ft";
        }
        public override bool Equals(object? obj) {
            if (obj is Ingatlan) {
                Ingatlan ujIngatlan = obj as Ingatlan;
                return this.HelyrajziSzam == ujIngatlan.HelyrajziSzam;
            }
            return false;
        }
    }
}
