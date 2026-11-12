using System;
using System.Collections.Generic;
using System.Text;

namespace MuholdApp
{
    internal class Muhold
    {
        public string Azonosito { get; set; }

        protected int sulyKg;

        public int SulyKg { get { return sulyKg; } 
            set { 
                if (value <= 0)
                    {
                    sulyKg = 100;
                    }
                else
                {
                    sulyKg = value;
                }
            } 
        }

        private static int osszesMuholdSzama;

        public static int OsszesMuholdSzama { get { return osszesMuholdSzama; } }

        public Muhold(string azonsoito,int sulyKg)
        {
            Azonosito = azonsoito;
            SulyKg = sulyKg;
            osszesMuholdSzama++;
        }

        public virtual int NapiKoltseg()
        {
            return SulyKg * 5;
        }
        public override string ToString()
        {
            return $"Műhold {Azonosito} | Tömeg: {SulyKg} kg | Napi költség:{NapiKoltseg()} EUR";
        }
    }
}
