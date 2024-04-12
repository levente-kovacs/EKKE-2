using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingatlan {
    internal class CsaladiHaz : Ingatlan {
        private byte telekSzelesseg;
        public byte TelekSzelesseg {
            get { return telekSzelesseg; }
            private set {
                if (value < 10 || value > 100) {
                    throw new Exception("telek szélesség");
                }
                if (value < Szelesseg) {
                    throw new Exception("Telek nem lehet keskenyebb, mint maga az ingatlan");
                }
                telekSzelesseg = value;
            }
        }
        private byte telekHosszusag;
        public byte TelekHosszusag {
            get { return telekHosszusag; }
            private set {
                if (value < 10 || value > 100) {
                    throw new Exception("telek hossz");
                }
                if (value < Hosszusag) {
                    throw new Exception("Telek nem lehet hosszabb, mint maga az ingatlan");
                }
                telekHosszusag = value;
            }
        }
        private byte szintek;
        public byte Szintek {
            get { return szintek; }
            private set {
                if (value < 1 || value > 3) {
                    throw new Exception("Szint nem jó");
                }
                szintek = value;
            }
        }
        public override ushort Alapterulet => (ushort)(base.Alapterulet * this.szintek);
        public ushort KertAlapterulet {
            get => (ushort)(telekSzelesseg * telekHosszusag - base.Alapterulet);
        }
        public CsaladiHaz(string helyrajziSzam, byte szelesseg, byte hosszusag, Allapot allapot, byte telekSzelesseg, byte telekHosszusag, byte szintek)
            : base(helyrajziSzam, szelesseg, hosszusag, allapot) {
            TelekSzelesseg = telekSzelesseg;
            TelekHosszusag = telekHosszusag;
            Szintek = szintek;
        }
        public CsaladiHaz(string helyrajziSzam, byte szelesseg, byte hosszusag, byte telekSzelesseg, byte telekHosszusag)
            : this(helyrajziSzam, szelesseg, hosszusag, Allapot.Ujepitesu, telekSzelesseg, telekHosszusag, 1) {
        }
        public override uint Vetelar() {
            if (this.Allapot == Allapot.Ujepitesu) {
                return (uint)(base.Vetelar() + base.Alapterulet * 50000 + KertAlapterulet * 200000);
            } else {
                return (uint)(base.Vetelar() + base.Alapterulet * 100000 + KertAlapterulet * 200000);
            }
        }
        public override string ToString() {
            return $"Az ingatlan és telek:\n\t- helyrajziszáma: {HelyrajziSzam}\n\t- ingatlan szélessége: {Szelesseg} m; ingatlan hossza: {Hosszusag} m;\n\t- szintek száma: {szintek}; ingatlan alapterülete: {Alapterulet} nm\n\t- állapota: {Allapot}\n\t- telek szélessége: {telekSzelesseg} m; telek hossza: {telekHosszusag} m; telek területe: {KertAlapterulet} nm\n\t- vételára: {Vetelar():n0} Ft";
        }
    }
}
