using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShuttle
{
    internal class Kuldetes
    {
        public string Kod { get; set; }
        public DateTime Kiloves { get; set; }
        public string Ursiklo { get; set; }
        public int NapokSzama { get; set; }
        public int OrakSzama { get; set; }
        public int EltoltottIdo
        {
            get
            {
                return NapokSzama * 24 + OrakSzama;
            }
        }
        public string Legitamaszpont { get; set; }
        public int Legenyseg { get; set; }

        public Kuldetes(string sor)
        {
            string[] t = sor.Split(';');
            Kod = t[0];
            string[] ido = t[1].Split('.');
            Kiloves = new DateTime(Convert.ToInt16(ido[0]), Convert.ToInt16(ido[1]), Convert.ToInt16(ido[2]));
            Ursiklo = t[2];
            NapokSzama = Convert.ToInt16(t[3]);
            OrakSzama = Convert.ToInt16(t[4]);
            Legitamaszpont = t[5];
            Legenyseg = Convert.ToInt16(t[6]);
        }
    }
}
