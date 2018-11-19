using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTvary
{
    public class KolekceTvaruGenerika<T> where T : I2dObject
    //public class KolekceTvaruGenerika<T> : IEnumerable<T> where T : I2dObject
    {
        //clenske promenne
        //private I2dObject aktivniTvar = null;
        private List<T> seznamTvaru = null;
         
        //konstruktory
        public KolekceTvaruGenerika(T[] poleTvaru)
        {
            this.seznamTvaru = new List<T>(poleTvaru);   //???1parametr. konstr. OK
        }     
        public KolekceTvaruGenerika(List<T> seznamTvaru)    //tento konstruktor nepouzivam
        {
            this.seznamTvaru = new List<T>(seznamTvaru);   //???1parametr. konstr. OK
        }

        //metody
        public string UrcitDatovyTyp(T tvar)
        {
            string s = "";
            //!!!!!!!!!!!!!
            //tyto 3 ify jsou asi zbytecne protoze datovy typ je "ukryt" uvnitr znakoveho retezce
            //tvar.GetType().ToString();   tj. vrati to  JmennyProstor.DatovyTypTvaru
            /*
            if (tvar is Obdelnik)
            {
                s = tvar.GetType().ToString();
            }
            if (tvar is Ctverec)
            {
                s = tvar.GetType().ToString();
                //tvar.GetType().
            }
            if (tvar is Trojuhelnik)
            {
                s = tvar.GetType().ToString();
            }
            
            if ( s.Contains('.') )  //ProjektTvary.Obdelnik  ProjektTvary.Ctverec  ProjektTvary.Trojuhelnik
            {                       //chci se zbavit jmenneho prostoru a tecky
                int index = s.IndexOf('.');
                s = s.Substring(index + 1);
            }
            else
            {
                s = "Neco jineho";
            }
            */

            //predelano 7.10.2018
            //Get type name without full namespace in C#
            //typeof(T).Name // class name, no namespace
            //typeof(T).FullName // namespace and class name
            //typeof(T).Namespace // namespace, no class name     
            //this.GetType().Name
            //this.GetType().FullName

            //1. OK
            s = tvar.GetType().Name;   //OK!!!

            #region Pokusy typeof(T) a Reflection a rekurze
            //2.
            //s = typeof(T).Name;   //vysledek je vzdy I2dObject!!!
            
            /*
            //3. rekurze a asi rozsirujici  tj. extension metoda!!!
            public static string CSharpName(this Type type)
            {
                var sb = new StringBuilder();
                var name = type.Name;
                if (!type.IsGenericType) return name;
                sb.Append(name.Substring(0, name.IndexOf('`')));
                sb.Append("<");
                sb.Append(string.Join(", ", type.GetGenericArguments()
                                                .Select(t => t.CSharpName())));
                sb.Append(">");
                return sb.ToString();
            }
            Maybe not the best solution (due to the recursion), but it works. Outputs look like:
            Dictionary<String, Object>
            */

            //4.
            /*
            //Suppose I have a nested class structure like this:
            namespace My.Namespace 
            {
                public class Foo 
                {
                    public class Bar 
                    {
                        public class Baz 
                        {
                            public string Test { get; set; }
                        }
                    }
                }
            }
            //I need to get the nested type name of Baz without the namespace, i.e. Foo+Bar+Baz in a generic method. Unfortunately, .Name will just return Baz and .FullName will give me the namespace as well. Right now I'm using this:
            protected T LoadSample<T>(string fileName) 
            {
                var t = typeof(T);
                var nestedTypeName = t.Namespace == null
                    ? t.FullName                                 // T is declared outside of a namespace
                    : t.FullName.Substring(t.Namespace.Length + 1);
                ...
            }
            //For example:
            //<baz>
            //    <test>Testing</test>
            //</baz>
            //Will be wrapped in an evelope like this:

            //<evelope>
            //    <messageType>urn:My.Namespace:Foo+Bar+Baz</messageType>
            //    <message>
            //        <test>Testing</test>
            //    </message>
            //</evelope>
            //But this just looks ugly. Is there a more standard method for getting just Foo+Bar+Baz in this situation?
    
            //Well, one brute force way of doing it is to recurse over the type's DeclaringType property:
            public static string TypeName (Type type)
            {
               if(type.DeclaringType == null)
                  return type.Name;

               return TypeName(type.DeclaringType) + "." + type.Name;
            }
            //Running the following program:
            static void Main(string[] args)
            {
               var type = typeof(My.Namespace.Foo.Bar.Baz);
               var name = TypeName(type);
            }
            //returns the name Foo.Bar.Baz as you would expect


            //It sounds like this might be what you are looking for I think.
            //Type.ReflectedType Property (.NET 4.5)
            GetType(t).ReflectedType;
            //I am not sure what version of the framework that you are using though.
            //this may only work if you nest it
            (GetType(GetType(t).ReflectedType).ReflectedType).ToString() + "." + (GetType(t).ReflectedType).ToString() + "." + (GetType(t).Name).ToString();
            //that is kind of messy too though.
            */
            #endregion

            return s;
        }

        #region Nahrazeno jedinou metodou VybratVsechny<T>()
        public List<Ctverec> VybratVsechnyCtverce()    //VybratVsechnyCtverce<T>()    //nahrazeno generickou metodou VybratVsechny<T>() 
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
        public List<Obdelnik> VybratVsechnyObdelniky()  //nahrazeno generickou metodou VybratVsechny<T>() 
        {
            //je to duplicitni kod :-(
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
        public List<Trojuhelnik> VybratVsechnyTrojuhelniky()  //nahrazeno generickou metodou VybratVsechny<T>() 
        {
            //je to duplicitni kod :-(
            List<Trojuhelnik> seznamTrojuhelniku = new List<Trojuhelnik>();

            foreach (I2dObject tvar in this.seznamTvaru)
            {
                if (tvar is Trojuhelnik)
                {
                    Trojuhelnik trojuhelnik = tvar as Trojuhelnik;
                    seznamTrojuhelniku.Add(trojuhelnik);
                }
            }

            if (seznamTrojuhelniku.Count > 0)
            {
                return seznamTrojuhelniku;
            }
            else
            {
                return null;
            }
        }
        #endregion
        public List<T> VybratVsechny<T>()                 //VybratVsechnyCtverce<T>()
        {
            List<T> seznamT = new List<T>();

            //pridano na pokusy s IComparable  ve tride _2dObjekt... ...nic mi to nedela???
            //seznamT.Sort();
                                                            //         T zde nejede
            foreach (I2dObject tvar in this.seznamTvaru)    //foreach (T tvar in this.seznamTvaru)
            {
                if (tvar is T)
                {
                    //T ctverec = tvar as T;     //as T   nelze???
                    T t = (T)tvar;
                    seznamT.Add(t);
                }
            }

            return (seznamT.Count > 0) ? seznamT : null;
        }

        #region Nahrazeno rozsirujicimi metodami z LINQ
        //pro          T   mi nejede null
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
        public I2dObject VybratTvarSNejmensimObvodem()
        {
            //je to duplicitni kod :-(
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
        #endregion        
        public I2dObject VybratTvarSNejvetsimObvodemLinq()        
        {
            //public T VybratTvarSNejvetsimObvodemLinq()   //takto lze zmenit hlavicku metody viz nize...

            //toto vraci double tj. nejvetsi obvod a ja potrebuji odkaz na objekt s nejvetsim obvodem!!!
            //double maximumObvod = this.seznamTvaru.Max(x => x.Obvod);
            //double maximumObvod2 = this.seznamTvaru.Select(x => x.Obvod).Max(); 
            //return maximumObvod2;

            //https://stackoverflow.com/questions/3188693/how-can-i-get-linq-to-return-the-object-which-has-the-max-value-for-a-given-prop
            //int max = items.Max(i => i.ID);
            //var item = items.First(x => x.ID == max);
            double obvodMaximum = this.seznamTvaru.Max(x => x.Obvod);
            I2dObject tvarMaximum = this.seznamTvaru.First(x => x.Obvod == obvodMaximum);
            return tvarMaximum;
        }
        public T VybratTvarSNejmensimObvodemLinq()            // T nahradilo I2dObject a jede to!!!
        {
            double obvodMinimum = this.seznamTvaru.Min(x => x.Obvod);
            T tvarMinimum = this.seznamTvaru.First(x => x.Obvod == obvodMinimum);
            return tvarMinimum;
        }
        public T VybratTvarSNejvetsiPlochouLinq()
        {
            double plochaMaximum = this.seznamTvaru.Max(x => x.Plocha);
            T tvarMaximum = this.seznamTvaru.First(x => x.Plocha == plochaMaximum);
            return tvarMaximum;
        }
        public T VybratTvarSNejmensiPlochouLinq()
        {
            double plochaMinimum = this.seznamTvaru.Min(x => x.Plocha);
            T tvarMinimum = this.seznamTvaru.First(x => x.Plocha == plochaMinimum);
            return tvarMinimum;
        }

        //pridano a NEPOUZIVAM
        //indexer tab tab
        //public object this[int index]   //vlastnost
        public T this[int index]
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

        //public 

        /*
        //explicitly...
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        */

        /*
        //implicit...
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        */


    }
}

