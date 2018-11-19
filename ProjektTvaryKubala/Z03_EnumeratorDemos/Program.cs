using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

//http://tomasp.net/blog/enumerators.aspx/
//http://programujte.com/clanek/2012100800-kolekce-v-net-2-yield-a-iteratory/
//http://jonskeet.uk/csharp/csharp2/iterators.html
//https://www.dotnetperls.com/ienumerable


namespace EnumeratorDemos
{
	partial class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Ukazka prace s enumeratory");
			EnumeratorsUsage();

			Console.WriteLine("Ukazka psani vlastnich enumeratoru ");
			CustomEnumerators1();

			Console.WriteLine("Enumeratory pomoci yield return v .NET 2.0");
			CustomEnumerators2();

            //pridano
            Console.WriteLine("Ukazka psani vlastnich enumeratoru tj. 3Moje ");
            CustomEnumerators3Moje();

            Console.WriteLine("Ukazka psani vlastnich enumeratoru tj. 4Moje ");
            CustomEnumerators4Moje();
		}
	}
}
