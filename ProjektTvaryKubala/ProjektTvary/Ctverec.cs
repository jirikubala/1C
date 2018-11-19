using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTvary
{
    public class Ctverec: _2dObject, I2dObject
    {
        //private List<int> seznamStran = null;   //presunuto do nadtridy

        public Ctverec()
            :this(0, 0, "Ctverec", "Zluta", 5)
        { 
        
        }

        public Ctverec(int x, int y, string nazev, string barva, int a)
            :base(x, y, nazev, barva)
        {
            this.seznamStran = new List<int>();

            this.seznamStran.Add(a);
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
                return this.seznamStran[0] * this.seznamStran[0];
            }
        }

        public double Obvod
        {
            get 
            {
                return 4 * this.seznamStran[0];
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
            return base.ToString() + string.Format(" a={0}", this.seznamStran[0]);
        }    
    }
}
