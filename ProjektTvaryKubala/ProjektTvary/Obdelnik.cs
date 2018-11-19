using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTvary
{
    public class Obdelnik: _2dObject, I2dObject
    {
        //private List<int> seznamStran = null;   //presunuto do nadtridy

        public Obdelnik()
            :this(0, 0, "Obdelnik", "Zelena", 6, 4)
        { 
        
        }

        public Obdelnik(int x, int y, string nazev, string barva, int a, int b)
            :base(x, y, nazev, barva)
        {
            this.seznamStran = new List<int>();

            this.seznamStran.Add(a);
            this.seznamStran.Add(b);
        }

        public List<int> Strany
        {
            get
            {
                return this.seznamStran;
            }
            set
            {
                this.seznamStran = value;
            }
        }

        public double Plocha
        {
            get
            {
                return this.seznamStran[0] * this.seznamStran[1];
            }
        }

        public double Obvod
        {
            get 
            {
                return 2 * (this.seznamStran[0] + this.seznamStran[1]);
            }
        }

        /*
        public override void Nakreslit()
        {
            Console.WriteLine("Obdelnik je jednoduche v console nakreslit:");

        }
        */

        public override string ToString()
        {
            return base.ToString() + string.Format(" a={0} b={1}", this.seznamStran[0], this.seznamStran[1]);
        }     
    }
}
