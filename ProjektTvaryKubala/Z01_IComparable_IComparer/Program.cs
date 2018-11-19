using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;  //potrebuji pro    IComparer

//https://support.microsoft.com/cs-cz/help/320727/how-to-use-the-icomparable-and-icomparer-interfaces-in-visual-c


namespace Z01_IComparable_IComparer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an arary of car objects.      
            Car[] arrayOfCars = new Car[8]
             {
                new Car("Ford",1992),
                new Car("Fiat",1988),
                new Car("Buick",1932),
                new Car("Ax",1977),
                new Car("Ford",1932),
                new Car("Dodge",1999),
                new Car("Trabant",1977),  
                new Car("Honda",1977)
             };

            // Write out a header for the output.
            Console.WriteLine("Array - Unsorted\n");

            foreach (Car c in arrayOfCars)
                //Console.WriteLine(c.Make + "\t\t" + c.Year);
                Console.WriteLine(c.ToString());

            // Demo IComparable by sorting array with "default" sort order.
            Array.Sort(arrayOfCars);
            Console.WriteLine("\nArray - Sorted by Make (Ascending - IComparable)\n");

            foreach (Car c in arrayOfCars)
                //Console.WriteLine(c.Make + "\t\t" + c.Year);
                Console.WriteLine(c.ToString());

            // Demo ascending sort of numeric value with IComparer.
            Array.Sort(arrayOfCars, Car.SortYearAscending());
            Console.WriteLine("\nArray - Sorted by Year (Ascending - IComparer)\n");

            foreach (Car c in arrayOfCars)
                //Console.WriteLine(c.Make + "\t\t" + c.Year);
                Console.WriteLine(c.ToString());

            // Demo descending sort of string value with IComparer.
            Array.Sort(arrayOfCars, Car.SortMakeDescending());
            Console.WriteLine("\nArray - Sorted by Make (Descending - IComparer)\n");

            foreach (Car c in arrayOfCars)
                //Console.WriteLine(c.Make + "\t\t" + c.Year);
                Console.WriteLine(c.ToString());

            // Demo descending sort of numeric value using IComparer.
            Array.Sort(arrayOfCars, Car.SortYearDescending());
            Console.WriteLine("\nArray - Sorted by Year (Descending - IComparer)\n");

            foreach (Car c in arrayOfCars)
                //Console.WriteLine(c.Make + "\t\t" + c.Year);
                Console.WriteLine(c.ToString());

            //pridano
            //sortMakeAscendingByLength
            // Demo descending sort of numeric value using IComparer.
            Array.Sort(arrayOfCars, Car.SortMakeAscendingByLength());
            Console.WriteLine("\nArray - Sorted by Make by Length (Ascending - IComparer)\n");

            foreach (Car c in arrayOfCars)
                //Console.WriteLine(c.Make + "\t\t" + c.Year);
                Console.WriteLine(c.ToString());

            //pridano
            Array.Reverse(arrayOfCars);
            Console.WriteLine("\nArray - Sorted by Make by Length (Descending - metoda Reverse)\n");

            foreach (Car c in arrayOfCars)
                //Console.WriteLine(c.Make + "\t\t" + c.Year);
                Console.WriteLine(c.ToString());

            Console.ReadLine();
        }
    }

    public class Car : IComparable
    {
        // Beginning of nested classes.

        // Nested class to do ascending sort on year property.
        private class SortYearAscendingHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Car c1 = (Car)a;
                Car c2 = (Car)b;

                if (c1.year > c2.year)
                    return 1;

                if (c1.year < c2.year)
                    return -1;

                else
                    return 0;
            }
        }

        // Nested class to do descending sort on year property.
        private class SortYearDescendingHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Car c1 = (Car)a;
                Car c2 = (Car)b;

                if (c1.year < c2.year)
                    return 1;

                if (c1.year > c2.year)
                    return -1;

                else
                    return 0;
            }
        }

        // Nested class to do descending sort on make property.
        private class SortMakeDescendingHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Car c1 = (Car)a;
                Car c2 = (Car)b;
                return String.Compare(c2.make, c1.make);
            }
        }

        //pridano
        // Nested class to do asscending sort on make property - ale podle delky retezce!!!
        private class SortMakeAscendingByLengthHelper : IComparer
        {
            //implicitni bezparametricky konstruktor

            int IComparer.Compare(object a, object b)
            {
                Car c1 = (Car)a;
                Car c2 = (Car)b;
                //return String.Compare(c2.make, c1.make);

                if (c1.make.Length > c2.make.Length)
                {
                    return 1;
                }
                else if (c1.make.Length < c2.make.Length)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        // End of nested classes.

        //clenske promenne
        private int year;
        private string make;

        //konstruktor
        public Car(string make, int year)
        {
            this.make = make;
            this.year = year;
        }

        //vlastnosti
        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }

        public string Make
        {
            get { return this.make; }
            set { this.make = value; }
        }

        //metody
        public override string ToString()
        {
            return this.make + "\t\t" + this.year;
        }

        // Implement IComparable CompareTo to provide default sort order.
        int IComparable.CompareTo(object obj)
        {
            Car c = (Car)obj;
            return String.Compare(this.make, c.make);
        }

        // Method to return IComparer object for sort helper.
        public static IComparer SortYearAscending()
        {
            return (IComparer)new SortYearAscendingHelper();
        }

        // Method to return IComparer object for sort helper.
        public static IComparer SortYearDescending()
        {
            return (IComparer)new SortYearDescendingHelper();
        }

        // Method to return IComparer object for sort helper.
        public static IComparer SortMakeDescending()
        {
            return (IComparer)new SortMakeDescendingHelper();
        }

        // Method to return IComparer object for sort helper.
        public static IComparer SortMakeAscendingByLength()
        {
            //OK    ?????????
            return (IComparer)new SortMakeAscendingByLengthHelper();

            //OK
            //return new SortMakeAscendingByLengthHelper();

            //OK
            //IComparer iComparer = new SortMakeAscendingByLengthHelper();
            //return iComparer;

            //OK
            //SortMakeAscendingByLengthHelper smablh = new SortMakeAscendingByLengthHelper();
            //return smablh;
        }
    }
}
