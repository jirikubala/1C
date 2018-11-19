using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTvary
{
    public class Trojuhelnik: _2dObject, I2dObject
    {
        //private int pocetStran = 3;
        //private List<int> seznamStran = null;   //presunuto do nadtridy

        public Trojuhelnik()
            :this(0, 0, "Trojuhelnik", "Modra", 7, 8, 9)
        { 
        
        }

        //public Trojuhelnik(int x, int y, string nazev, string barva, int a, int b, int c)
        private Trojuhelnik(int x, int y, string nazev, string barva, int a, int b, int c)
            :base(x, y, nazev, barva)
        {
            this.seznamStran = new List<int>();

            this.seznamStran.Add(a);
            this.seznamStran.Add(b);
            this.seznamStran.Add(c);
        }

        public static Trojuhelnik GetInstance(int x, int y, string nazev, string barva, int a, int b, int c)
        {
            if (a<=0 || b<=0 || c<=0)
            {
                return null;   //trojuhelnik nelze sestrojit
            }

            if ( ((a+b)<=c) || ((a+c)<=b) || ((b+c)<=a) )
            {
                return null;   //trojuhelnik nelze sestrojit
            }

            return new Trojuhelnik(x, y, nazev, barva, a, b, c);     
        }

        public List<int> Strany
        {
            get
            {
                return this.seznamStran;
            }
            set
            {
                //neprovadim kontrolu na 0 a na zaporna cisla a na trojuhelnikovou nerovnost
                this.seznamStran = value;
            }
        }

        public double Plocha
        {
            get 
            { 
                //http://www.idust.g6.cz/2011/08/c-i-obsah-trojuhelnika/
                int a = this.seznamStran[0];
                int b = this.seznamStran[1];
                int c = this.seznamStran[2];

                double s = (double)(a + b + c) / 2.0;
                double S = s * (s - a) * (s - b) * (s - c);
                S = Math.Pow(S, 0.5);   //druha odmocnina z S

                return S;
            }
        }

        public double Obvod
        {
            get 
            {
                return Strany[0] + Strany[1] + Strany[2]; 
            }
        }

        public bool JePravouhly()
        {        
            int[] poleStran = new int[this.seznamStran.Count];  //[Strany.Count];
            Strany.CopyTo(poleStran);   //nechci menit puvodni poradi stran
            Array.Sort(poleStran);   //prepona bude prvni nebo posledni prvek???
            //                 c na druhou               =   a na druhou               + b na druhou
            //pravouhly 25=16+9  5^2=4^2+3^2
            //                 prepona je nejdelsi          odvesna1                     odvesna2
            bool jePravouhly = Math.Pow(poleStran[2], 2) == (Math.Pow(poleStran[1], 2) + Math.Pow(poleStran[0], 2));
            
            return jePravouhly;
        }

        /*
        public override void Nakreslit()
        {
            Console.WriteLine("Tojuhelnik neni jednoduche v console nakreslit.");
        }
        */

        public override string ToString()
        {
            return base.ToString() + string.Format(" a={0} b={1} c={2}", this.seznamStran[0], this.seznamStran[1], this.seznamStran[2]);
        }

        //pridano

    }
}
