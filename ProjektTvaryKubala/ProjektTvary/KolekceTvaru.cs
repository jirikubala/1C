using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTvary
{
    //negenericka verze kolekce - NEPOUZIVAM
    public class KolekceTvaru 
    //public class KolekceTvaru<T> where T : I2dObject
    //public class AGenericClass<T> where T : IComparable<T> { }
    //public class KolekceTvaru<T>
    {
        //private I2dObject aktivniTvar = null;
        private List<I2dObject> seznamTvaru = null;
         
        public KolekceTvaru(I2dObject[] poleTvaru)
        {
            this.seznamTvaru = new List<I2dObject>(poleTvaru);   //???1parametr. konstr.
        }

        public KolekceTvaru(List<I2dObject> seznamTvaru)
        {
            this.seznamTvaru = new List<I2dObject>(seznamTvaru);   //???1parametr. konstr.
        }

        public String UrcitDatovyTyp(I2dObject tvar)
        {
            string s = "";
            if (tvar is Obdelnik)
            {
                s = tvar.GetType().ToString();
            }
            if (tvar is Ctverec)
            {
                s = tvar.GetType().ToString();
            }
            if (tvar is Trojuhelnik)
            {
                s = tvar.GetType().ToString();
            }

            if ( s.Contains('.') )  //ProjektTvary.Obdelnik  ProjektTvary.Ctverec  ProjektTvary.Trojuhelnik
            {
                int index = s.IndexOf('.');
                s = s.Substring(index + 1);
            }
            else
            {
                s = "Neco jineho";
            }

            return s;
        }

        public List<Ctverec> VybratVsechnyCtverce()
        {
            List<Ctverec> seznamCtvercu = new List<Ctverec>();

            foreach (I2dObject tvar in this.seznamTvaru)
            {
                if (tvar is Ctverec)
                {
                    Ctverec ctverec = tvar as Ctverec;
                    seznamCtvercu.Add(ctverec);
                }
            }

            if (seznamCtvercu.Count > 0)
            {
                return seznamCtvercu;
            }
            else
            {
                return null;
            }
        }

        //je to duplicitni kod :-(
        public List<Obdelnik> VybratVsechnyObdelniky()
        {
            List<Obdelnik> seznamObdelniku = new List<Obdelnik>();

            foreach (I2dObject tvar in this.seznamTvaru)
            {
                if (tvar is Obdelnik)
                {
                    Obdelnik obdelnik = tvar as Obdelnik;
                    seznamObdelniku.Add(obdelnik);
                }
            }

            if (seznamObdelniku.Count > 0)
            {
                return seznamObdelniku;
            }
            else
            {
                return null;
            }
        }

        public I2dObject VybratTvarSNejvetsimObvodem()
        {
            if (this.seznamTvaru.Count == 0)
            {
                return null;
            }

            if (this.seznamTvaru.Count == 1)
            {
                return this.seznamTvaru[0];
            }

            I2dObject tvarMaximum = this.seznamTvaru[0];
            for (int i = 1; i < this.seznamTvaru.Count; i++)
            {
                if (this.seznamTvaru[i].Obvod > tvarMaximum.Obvod)
                {
                    tvarMaximum = this.seznamTvaru[i];
                }
            }
            return tvarMaximum;
        }

        //je to duplicitni kod :-(
        public I2dObject VybratTvarSNejmensimObvodem()
        {
            if (this.seznamTvaru.Count == 0)
            {
                return null;
            }

            if (this.seznamTvaru.Count == 1)
            {
                return this.seznamTvaru[0];
            }

            I2dObject tvarMinimum = this.seznamTvaru[0];
            for (int i = 1; i < this.seznamTvaru.Count; i++)
            {                      //operator <   je jedina zmena!!!
                if (this.seznamTvaru[i].Obvod < tvarMinimum.Obvod)
                {
                    tvarMinimum = this.seznamTvaru[i];
                }
            }
            return tvarMinimum;
        }



        //indexer tab tab
        //public object this[int index]   //vlastnost
        public I2dObject this[int index]
        {
            get
            {
                return this.seznamTvaru[index];
            }
            set
            {
                this.seznamTvaru[index] = value;  //value resi hodnotu ktera mi prichazi
            }
        }

        //pridat vlastnost Count
        public int Count
        {
            //jen pro cteni
            get
            {
                return this.seznamTvaru.Count;
            }
        }
    }
}
