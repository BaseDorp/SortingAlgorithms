using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms
{
    class Sort
    {
        public static List<int> theInts = new List<int>();
        public static List<Guid> theGuids = new List<Guid>();
        public static List<Double> theDoubles = new List<Double>();

        public static int guidsListLength;
        public static int doublesListLength;

        /// <summary>
        /// Splits the CSV, putting each of the items into the appropriate list. you can then reference them using, for example, Sort.theInts[999999] to find the final int
        /// </summary>
        public static void FileReader()
        {
            using (var streamReader = new StreamReader(@"C:\Users\Wiinn\Desktop\Algorithms\jb.csv"))//this is the location of the CSV file it will read
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

        public static List<Guid> BubbleSort(List<Guid> theData)
        {
            int b;
            for (int s = 0; s <= guidsListLength - 2; s++)
            {
                for (int r = 0; r <= guidsListLength - 2; r++)
                {
                    if (Guid1IsGreater(theGuids[r], theGuids[r + 1]))
                    {
                        b = theGuids[r + 1];
                        theGuids[r + 1] = theGuids[r];
                        theGuids[r] = b;
                    }
                }
            }
        }
        /// <summary>
        /// For the sake of comparing guids, this function returns true when the first guid is greater than the second, determined by the Guid.CompareTo method.
        /// Guid.CompareTo's documentation on how it compares:
        /// The CompareTo method compares the GUIDs as if they were values provided to the Guid(Int32, Int16, Int16, Byte[]) constructor, as follows:
        /// It compares the UInt32 values, and returns a result if they are unequal. If they are equal, it performs the next comparison.
        /// It compares the first UInt16 values, and returns a result if they are unequal. If they are equal, it performs the next comparison.
        /// It compares the second UInt16 values, and returns a result if they are unequal. If they are equal, it performs the next comparison.
        /// If performs a byte-by-byte comparison of the next eight Byte values. When it encounters the first unequal pair, it returns the result.
        /// Otherwise, it returns 0 to indicate that the two Guid values are equal.
        /// 
        /// In its example, it demonstrates that a value of -1 is "less than", 0 is "equals", and 1 is "greater than".
        /// </summary>
        static bool Guid1IsGreater(Guid guid1, Guid guid2)
        {
            if (guid1.CompareTo(guid2) == 1)
                return true;
            else
                return false;
        }
        public static List<Double> BubbleSort(List<double> theData)
        {
            int b;
            for (int s = 0; s <= doublesListLength - 2; s++)
            {
                for(int r = 0; r <= doublesListLength - 2; r++)
                {
                    if(theDoubles[r] > theDoubles[r+1])
                    {
                        b = theDoubles[r + 1];
                        theDoubles[r + 1] = theDoubles[r];
                        theDoubles[r] = b;
                    }
                }
            }
        }
    }
}
