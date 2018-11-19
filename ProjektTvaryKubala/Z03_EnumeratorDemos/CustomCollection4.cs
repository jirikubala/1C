using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EnumeratorDemos
{
	class CustomCollection4Moje : IEnumerable<int>
	{
		// Trida ktera se bude pouzivat k ukladani dat
		class Node
		{
			// data v node
			public int Value;
			// dalsi node v retezu
			public Node Next;
		}

        // Trida - enumerator - ktera se pouziva k prochazeni 
        // pres prvky v kolekci. Bere jako parametr node a postupne
        // prochazi zretezeny seznam
        class MyEnumerator : IEnumerator<int>
        {
            Node _first, _current = null;

            public MyEnumerator(Node node)
            {
                _first = node;
            }

            // Vraci aktualni prvek
            public int Current
            {
                get { return _current.Value; }
            }

            // Vraci aktualni prvek jako objekt (kvuli .NET 1.0 enumeratorum)
            object IEnumerator.Current
            {
                get { return Current; }
            }

            // Posouva enumerator na dalsi hodnotu
            // Pri prvnim volani by mela nastavit Current na prvni hodnotu
            public bool MoveNext()
            {
                if (_current == null)
                    // prvni volani
                    _current = _first;
                else
                    // posun na dalsi prvek
                    _current = _current.Next;

                return _current != null;
            }

            // Reset enumeratoru pred zacatek
            public void Reset()
            {
                _current = null;
            }

            // Enumeratory jsou IDisposable
            public void Dispose()
            {
            }
        }

		// prvni node
		Node _first;
        //pridano
        private Node[] poleNode = null;

		// Vytvari kolekci z pole integeru
        public CustomCollection4Moje(int[] prvky)
		{
            if (prvky.Length > 0)
            {
                Node n = new Node();
                _first = n;

                this.poleNode = new Node[prvky.Length];
                n.Value = prvky[0];

                for (int i = 1; i < prvky.Length; i++)
                {
                    Node tmp = new Node();
                    tmp.Value = prvky[i];
                         
                    //bez tohoto se mi to neposouva na dalsi prvek
                    //???
                    //pokud toto zakazu tak to neumi enumerovat vnitrni kolekci tj. poleNode
                    //n.Next = tmp;   //Next bude vzdy null tj. zde to neresim pouzivam pole
                    //n = tmp;

                    this.poleNode[i] = tmp;
                }
            }
		}

        /*
		// Zjednoduseny zpusob psani enumeratoru v .NET 2.0
		// pomoci prikazu yield return - tridu enumeratoru
		// vygeneruje compilator za nas :-)
		public IEnumerator<int> GetEnumerator()
		{
			Node current = _first;
			while(current != null)
			{
				// yield return pouze posle data volajicim (kdyz si o ne
				// volajici pomoci MoveNext a Current rekne)
				yield return current.Value;

				// pri dalsim pristupu ke Current (po volani MoveNext) se
				// vykona kod az po dalsi volani yield return
				current = current.Next;
			}
		}
        */
        // Vraci enumerator - tedy objekt pomoci ktereho se
        // bude prochazet prez prvky kolekce
        public IEnumerator<int> GetEnumerator()
        {
            return new MyEnumerator(_first);
        }

		// Z duvodu zpetne kompatibility je krom rozhrani 
		// IEnumerable<int> implementovat i IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
	}

	partial class Program
	{
		static void CustomEnumerators4Moje() 
		{
            CustomCollection4Moje col = new CustomCollection4Moje
				(new int[] { 1,2,3,4,5,6,7,8,9 });


			// pomoci forach
			foreach(int i in col)
				Console.Write("{0},", i);
			Console.WriteLine();

            
			// pomoci enumeratoru
			IEnumerator<int> en = col.GetEnumerator();
			while(en.MoveNext())
			{
				Console.Write("{0},",en.Current);
			}
			Console.WriteLine();
            
		}
	}
}
