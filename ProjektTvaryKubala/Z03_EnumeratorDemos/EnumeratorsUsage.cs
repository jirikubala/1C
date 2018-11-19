using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EnumeratorDemos
{
	partial class Program
	{
		// --------------- UKAZKA PRACE S ENUMERATORY --------------- \\
		static void EnumeratorsUsage()
		{
			// Pole take implementuje IEnumerable
			int[] collection1 = new int[] { 1,2,3,4,5 };

			// List<T> implementuje IEnumerable
			List<int> collection2 = new List<int>();
			collection2.Add(1);
			collection2.Add(2);
			collection2.Add(3);
			collection2.Add(4);
			collection2.Add(5);


			// konstrukce forach v C# pracuje vnitrne s enumeratory
            Console.WriteLine("1.");
			foreach(int n in collection1)
			{                
				Console.Write(n);
			}
			Console.WriteLine();


			// predchazejici forach je ve skutecnosti pouze zkratka za:
			IEnumerator enumerator1 = collection1.GetEnumerator();

			// metoda MoveNext je pred spustenim na "-1" pozici a vraci
			// false pote co dojde na konec seznamu
            Console.WriteLine("2.");
			while(enumerator1.MoveNext())
			{
				// pomoci vlastnosti Current se pristupuje k aktualnimu prvku
				Console.Write((int)enumerator1.Current);
			}
			Console.WriteLine();


			// situace je jeste slozitejsi, protoze pole vraci typ 
			// IEnumerator (vlastnost Current je typu object a musi se pretypovavat)

			// Kolekce v .NET 2.0 mohou krom typu IEnumerator vracet i 
			// genericky IEnumerator<T> ktery ma vlastnost Current odpovidajiciho typu

			// Prace s enumeratory v .NET 2.0
            Console.WriteLine("3.");
			IEnumerator<int> enumerator2 = collection2.GetEnumerator();
			while(enumerator2.MoveNext())
			{
				Console.Write(enumerator2.Current);
			}
			Console.WriteLine();



            //pridano Moje
            // Prace s enumeratory v .NET 2.0
            int[] collection3Moje = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            Console.WriteLine("4. collection3Moje");
            // konstrukce forach v C# pracuje vnitrne s enumeratory
            foreach (int n in collection3Moje)
            {
                Console.Write(n);
            }
            Console.WriteLine();

            Console.WriteLine("5. collection3Moje");
            //neumim udelat genericky tj. IEnumerator<int>
            IEnumerator enumerator3Moje = collection3Moje.GetEnumerator();
            while (enumerator3Moje.MoveNext())
            {
                Console.Write(enumerator3Moje.Current);
            }
            Console.WriteLine();
            Console.WriteLine();
		}
	}
}
