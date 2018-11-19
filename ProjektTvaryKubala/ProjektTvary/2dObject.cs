using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTvary
{
    public abstract class _2dObject //: I2dObject      //pridano
    //public abstract class _2dObject     : IComparable
    {
        protected static int pocet = 0;
        protected int id = pocet;
        protected string nazev = "Tvar obecny";
        protected string barva = "Zadna barva";

        //levy horni roh tvaru
        protected int x = 0;
        protected int y = 0;

        protected List<int> seznamStran = null;  //az pro potomky
        
        //?????????????  musi to zde byt???  v Obdelnik to hlasi chybu... tj. nemam napsany viceparametricky konstruktor >>> uz jsem napsal viceparametricky konstruktor a toto nepotrebuji
        public _2dObject()
            :this(7, 3, "Tvar", "Bez barvy")
        { 
            
        }
        
        public _2dObject(int x, int y, string nazev, string barva)
        {
            this.x = x;
            this.y = y;
            this.nazev = nazev;
            this.barva = barva;
            this.id = ++_2dObject.pocet;
        }

        //public abstract void Nakreslit();

        public override string ToString()
        {
            return string.Format("{0}{1} x={2} y={3} barva={4}", this.nazev, this.id, this.x, this.y, this.barva);
        }

        /*
        public int CompareTo(object obj)
        {
            _2dObject obj2D = obj as _2dObject;

            if (this.id > obj2D.id)
            {
                return 1;
            }
            else if (this.id < obj2D.id)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        */
    }
}
