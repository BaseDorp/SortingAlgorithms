using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SortingAlgorithms
{
    class Sort
    {
        public static List<int> theInts = new List<int>();
        public static List<Guid> theGuids = new List<Guid>();
        public static List<Double> theDoubles = new List<Double>();

        List<double> TestDoubles = new List<double> {1,4,5,8,2,10};

        public static int guidsListLength;
        public static int doublesListLength;

        /// <summary>
        /// Splits the CSV, putting each of the items into the appropriate list. you can then reference them using, for example, Sort.theInts[999999] to find the final int
        /// </summary>
        public static void FileReader()
        {
            using (var streamReader = new StreamReader(@"D:\C#Projects\Algorithms\SortingAlgorithms\SortingAlgorithms\SortingAlgorithms\bin\Debug\netcoreapp2.1\jb.csv"))//this is the location of the CSV file it will read
            {
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    var values = line.Split(',');
                    theInts.Add(Int32.Parse(values[0]));
                    theGuids.Add(Guid.Parse(values[1]));
                    theDoubles.Add(Double.Parse(values[2]));

                    guidsListLength = theGuids.Count;
                    doublesListLength = theDoubles.Count;
                }
            }
        }

        public static void ShowElementsOfList(List<Double> d)
        {
            foreach (var element in d)
            {
                Console.Write(element + " ");
            }
            Console.Write("\n");
        }
        public static void ShowElementsOfList(List<Guid> g)
        {
            foreach (var element in g)
            {
                Console.Write(element + " ");
            }
            Console.Write("\n");
        }
        /// <summary>
        /// For the sake of comparing guids, this function returns true when the first guid is greater than the second, determined by the Guid.CompareTo method.
        /// Guid.CompareTo's documentation on how it compares:
        /// The CompareTo method compares the GUIDs as if they were values provided to the Guid(Int32, Int16, Int16, Byte[]) constructor, as follows:
        /// It compares the UInt32 values, and returns a result if they are unequal. If they are equal, it performs the next comparison.
        /// It compares the first UInt16 values, and returns a result if they are unequal. If they are equal, it performs the next comparison.
        /// If performs a byte-by-byte comparison of the next eight Byte values. When it encounters the first unequal pair, it returns the result.
        /// Otherwise, it returns 0 to indicate that the two Guid values are equal.
        /// In its example, it demonstrates that a value of -1 is "less than", 0 is "equals", and 1 is "greater than".
        /// </summary>
        static bool Guid1IsGreater(Guid guid1, Guid guid2)
        {
            if (guid1.CompareTo(guid2) == 1)
                return true;
            else
                return false;
        }

        // User Interface ----------------------------------------------------------------------------------
        public Sort()
        {
            FileReader();
            int input = 0;
            do
            {
                Console.WriteLine("Please select the type of sort you would like to do. (Enter 1-4)");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. Selection Sort\n2. Bubble Sort\n3. Radix Sort (Coming Soon)\n4. Shell Sort (Coming Soon)");
                Console.ResetColor();
                input = Int32.Parse(Console.ReadLine());
                if (input < 0 || input > 4)
                {
                    Console.WriteLine("Sorry, that is not a correct input. Please try again.");
                }
            } while (input < 0 || input > 4);
            switch (input)
            {
                case 1:
                    Selection(theGuids);
                    Selection(theDoubles);
                    break;
                case 2:
                    BubbleSort(theGuids);
                    BubbleSort(theDoubles);
                    break;
                case 3:
                    Console.WriteLine("This hasn't been added yet.");
                    break;
                case 4:
                    Console.WriteLine("This hasn't been added yet.");
                    break;
            }
        }

        /// <summary>
        /// Bubble Sort Method: Jared Bronstein ---------------------------------------------
        /// References
        /// <see cref="https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-3.php"/>
        /// <see cref="https://www.geeksforgeeks.org/bubble-sort/"/>
        /// <see cref="https://www.c-sharpcorner.com/UploadFile/3d39b4/bubble-sort-in-C-Sharp/"/>
        /// </summary>
        /// <param name="theData">The list of Guids or Doubles provided by the CSV file</param>
        /// <returns>The sorted list of the CSV file data</returns>
        public static void BubbleSort(List<Guid> theData)
        {
            Console.WriteLine("Sorting...");
            Guid b;
            for (int s = 0; s <= theData.Count - 2; s++)
            {
                for (int r = 0; r <= theData.Count - 2; r++)
                {
                    if (Guid1IsGreater(theData[r], theData[r + 1]))
                    {
                        b = theData[r+1];
                        theData[r + 1] = theData[r];
                        theData[r] = b;
                    }
                }
            }
            foreach (Guid item in theData)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Done!");
        }
        public static void BubbleSort(List<double> theData)
        {
            Console.WriteLine("Sorting...");
            double b;
            for (int s = 0; s <= theData.Count - 2; s++)
            {
                for (int r = 0; r <= theData.Count - 2; r++)
                {
                    if (theData[r] > theData[r + 1])
                    {
                        b = theData[r + 1];
                        theData[r + 1] = theData[r];
                        theData[r] = b;
                    }
                }
            }
            foreach (double item in theData)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Done!");
        }


        // Selection Sort -------------------------------------------------------------------
        /// <summary>
        /// <see cref="https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-11.php"
        /// </summary>
        /// <param name="g"></param>
        void Selection(List<Guid> g)
        {
            Console.WriteLine("Sorting...");
            Guid temp;
            for (int i = 0; i < g.Count; i++)
            {
                for (int n = i+1; n < g.Count; n++)
                {
                    if (Guid1IsGreater(g[n], g[i]))
                    {
                        temp = g[i];
                        g[i] = g[n];
                        g[n] = temp;
                    }
                }
            }
            foreach (Guid item in g)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Done!");
        }

        void Selection(List<double> d)
        {
            double temp = 0;
            Console.WriteLine("Sorting...");
            for (int i = 0; i < d.Count; i++)
            {
                for (int n = i+1; n < d.Count; n++)
                {
                    if (d[n] < d[i])
                    {
                        temp = d[i];
                        d[i] = d[n];
                        d[n] = temp;
                    }
                }
                // Console.WriteLine("{0}. {1}",i, d[i]);
            }
            foreach (double item in d)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Done!");
        }


    }
}
