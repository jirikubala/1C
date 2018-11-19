using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTvary
{
    class Program
    {
        static void Main(string[] args)
        {
            Obdelnik o1 = new Obdelnik();
            Obdelnik o2 = new Obdelnik(5, 2, "MujObdelnik", "Oranzova", 10, 3);
            Ctverec c1 = new Ctverec();
            Ctverec c2 = new Ctverec(7, 3, "MujCtverec", "Fialova", 12);
            Trojuhelnik t1 = new Trojuhelnik();
            //Trojuhelnik t2 = Trojuhelnik.GetInstance(2, 4, "MujTrojuhelnik", "Bila", 10, 5, 8);
            Trojuhelnik t2 = Trojuhelnik.GetInstance(2, 4, "MujPravouhlyTrojuhelnik", "Bila", 3, 5, 4);  //pravouhly trojuhelnik
            //Trojuhelnik t2 = Trojuhelnik.GetInstance(2, 4, "MujTrojuhelnik", "Bila", 10, 5, 3);  //chyba trojuhelnik nelze sestrojit tj. nesouhlasi trojuhelnikova nerovnost
            //Trojuhelnik t2 = Trojuhelnik.GetInstance(2, 4, "MujTrojuhelnik", "Bila", -10, 5, 8);  //chyba zaporne cislo na vstupu jako delka strany
            if (t2 == null)
            {
                Console.WriteLine("Konec programu - chyba v zadani stran trojuhelniku.");
                return;   //ukonceni programu
            }

            #region Pomocny vypis poleTvaru - bazova trida _2dObject[]
            /*
            Console.WriteLine("Pomocny vypis poleTvaru>>>");
            //_2dObject[] poleTvaru = new _2dObject[6];
            _2dObject[] poleTvaru = { o1, o2, c1, c2, t1, t2 };

            for (int i = 0; i < poleTvaru.Length; i++)
            {
                Console.WriteLine( poleTvaru[i].ToString() );
                if (poleTvaru[i] is Trojuhelnik)
                {
                    Trojuhelnik trojuhelnik = poleTvaru[i] as Trojuhelnik;
                    string jeNeni = (trojuhelnik.JePravouhly()) ? "JE" : "NENI";
                    Console.WriteLine("Trojuhelnik {0} pravohuly.", jeNeni);
                    Console.WriteLine("Obvod trojuhelniku je {0}", trojuhelnik.Obvod);
                    Console.WriteLine("Obsah trojuhelniku je {0}", trojuhelnik.Plocha);
                }

                Console.WriteLine("----------------------");
            }
            Console.WriteLine("^--------------------^");
            Console.WriteLine("^--------------------^");
            */
            #endregion

            I2dObject[] poleTvaruProKolekci = { o1, o2, c1, c2, t1, t2,
            //I2dObject[] poleTvaruProKolekci = { o1, o2, o1, o2, t1, t2,     //takto neni zadny ctverec
                                                new Obdelnik(), 
                                                Trojuhelnik.GetInstance(0, 0, "Troj", "red", 100, 200, 250),
                                                new Obdelnik(2, 4, "Obd", "blue", 2, 1)
                                              };
            //KolekceTvaru kolekceTvaru = new KolekceTvaru(poleTvaruProKolekci);   //pro negenerickou tridu KolikceTvaru
            KolekceTvaruGenerika<I2dObject> kolekceTvaru = new KolekceTvaruGenerika<I2dObject>(poleTvaruProKolekci);  //pro generickou tridu KolikceTvaruGenerika

            Console.WriteLine("1.>>>");
            Console.WriteLine("Datovy typ instance predane v parametru je {0}", kolekceTvaru.UrcitDatovyTyp(o1));
            Console.WriteLine("Datovy typ instance predane v parametru je {0}", kolekceTvaru.UrcitDatovyTyp(kolekceTvaru[2]));  //kolekceTvaru[2] je Ctverec
            Console.WriteLine("Datovy typ instance predane v parametru je {0}", kolekceTvaru.UrcitDatovyTyp(t2));
            Console.WriteLine("^--------------------^");


            Console.WriteLine("2.>>>");
            //foreach (Ctverec ctverec in kolekceTvaru.VybratVsechnyCtverce())
            //foreach (Ctverec ctverec in kolekceTvaru.VybratVsechny<Ctverec>())
            //{
            //    Console.WriteLine( ctverec.ToString() );
            //}
            if (kolekceTvaru.VybratVsechny<Ctverec>() != null)
                kolekceTvaru.VybratVsechny<Ctverec>().ForEach(x => Console.WriteLine(x));  //.WriteLine(x + " ")
            Console.WriteLine("----------------------");

            if (kolekceTvaru.VybratVsechny<Obdelnik>() != null)
                kolekceTvaru.VybratVsechny<Obdelnik>().ForEach(x => Console.WriteLine(x));
            Console.WriteLine("----------------------");

            if (kolekceTvaru.VybratVsechny<Trojuhelnik>() != null)
                kolekceTvaru.VybratVsechny<Trojuhelnik>().ForEach(x => Console.WriteLine(x));
            Console.WriteLine("----------------------");

            //IEnumerable<Trojuhelnik> vyberPravouhlychTrojuhelniku =
            //    kolekceTvaru.VybratVsechny<Trojuhelnik>().Where(x => x.JePravouhly());
            List<Trojuhelnik> vyberPravouhlychTrojuhelniku =
                kolekceTvaru.VybratVsechny<Trojuhelnik>().Where(x => x.JePravouhly()).ToList();
            vyberPravouhlychTrojuhelniku.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("^--------------------^");


            Console.WriteLine("3.>>> (neresim chybovy stav, ze se nic nevybere tj. ze zadny tvar neexistuje)");
            //Console.WriteLine("Tvar s nejvetsim obvodem je: {0}", kolekceTvaru.VybratTvarSNejvetsimObvodem().ToString() );
            Console.WriteLine("Tvar s nejvetsim obvodem (LINQ) je: {0}", kolekceTvaru.VybratTvarSNejvetsimObvodemLinq().ToString());
            //Console.WriteLine("Tvar s nejvetsim obvodem ma obvod: {0}", kolekceTvaru.VybratTvarSNejvetsimObvodem().Obvod.ToString());
            Console.WriteLine("Tvar s nejvetsim obvodem (LINQ) ma obvod: {0}", kolekceTvaru.VybratTvarSNejvetsimObvodemLinq().Obvod.ToString());
            Console.WriteLine("----------------------");

            Console.WriteLine("Tvar s nejmensim obvodem (LINQ) je: {0}", kolekceTvaru.VybratTvarSNejmensimObvodemLinq().ToString());
            Console.WriteLine("Tvar s nejmensim obvodem (LINQ) ma obvod: {0}", kolekceTvaru.VybratTvarSNejmensimObvodemLinq().Obvod.ToString());
            Console.WriteLine("----------------------");

            Console.WriteLine("Tvar s nejvetsi plochou (LINQ) je: {0}", kolekceTvaru.VybratTvarSNejvetsiPlochouLinq().ToString());
            Console.WriteLine("Tvar s nejvetsi plochou (LINQ) ma plochu: {0}", kolekceTvaru.VybratTvarSNejvetsiPlochouLinq().Plocha.ToString());
            Console.WriteLine("----------------------");

            Console.WriteLine("Tvar s nejmensi plochou (LINQ) je: {0}", kolekceTvaru.VybratTvarSNejmensiPlochouLinq().ToString());
            Console.WriteLine("Tvar s nejmensi plochou (LINQ) ma plochu: {0}", kolekceTvaru.VybratTvarSNejmensiPlochouLinq().Plocha.ToString());
            Console.WriteLine("^--------------------^");

            Console.ReadLine();
        }
    }
}
