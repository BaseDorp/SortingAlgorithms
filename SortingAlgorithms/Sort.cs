using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SortingAlgorithms
{
    /// <summary>
    /// Use this commenting structure for each method. two references for each sorting method
    /// 8 total methods
    /// Read in a csv file as the input to your sorting methods, File.ReadLine to read one line of data at a time
    /// Example URL inclusion:
    /// Justin doing: Shell Sort, Radix Sort
    /// <see cref="url"/>
    /// /// <see cref="url"/>
    /// </summary>
    public static class Sort
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
            using (var streamReader = new StreamReader(@"C:\CSVfolder\jc-ma.csv"))//this is the location of the CSV file it will read
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

        public static double getMaximumValue(List<Double> dList)//finds the largest double in the list, for bucket sort
        {
            double maximumValue = dList[0];
            int listSize = dList.Count;
            for (int i = 1; i < listSize; i++)
            {
                if(dList[i] > maximumValue)
                {
                    maximumValue = dList[i];
                }
            }
            return maximumValue;
        }
        public static double getMinimumValue(List<Double> dList)//finds the smallest double in the list, for bucket sort
        {
            double minimumValue = dList[0];
            int listSize = dList.Count;
            for (int i = 1; i < listSize; i++)
            {
                if (dList[i] < minimumValue)
                {
                    minimumValue = dList[i];
                }
            }
            return minimumValue;
        }

        /// <summary>
        /// Justin's Bucket Sorts
        /// </summary>
        /// <param name="theData"></param>
        /// <returns></returns>
        public static List<Guid> BucketSort(List<Guid> theData)
        {
            return new List<Guid>();
        }
        public static List<Double> BucketSort(List<Double> theData)
        {
            return new List<Double>();
        }

        /// <summary>
        /// Justin's Shell Sorts
        /// Currently implemented shell sort is a total cut and paste, just to examine functionality!
        /// From: <see cref="https://www.tutorialspoint.com/shell-sort-program-in-chash"/>
        /// From: <see cref="https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-1.php"/>
        /// From: <see cref="https://www.geeksforgeeks.org/shellsort/"/>
        /// </summary>
        /// <param name="theData"></param>
        /// <returns></returns>
        /// 

        public static int ShellSort(List<Double> dList)//Time complexity: O(N^2). Gap size is reduced by half every iteration. too few gaps slow down the passes, and too many gaps produces overhead
        {
            int n = dList.Count;//n is the size of our list

            //Sort using large gaps, and reduce gap size gradually
            for (int gap = n / 2; gap > 0; gap /= 2)//our gap sizes will be 500k, then 250k, then 125k, etc...
            {
                //Perform insertion sorts using the current gap size
                for (int i = gap; i < n; i += 1)
                {

                    double temp = dList[i];

                    //Move previously sorted elements forwards to find the right spot for this one
                    int j;
                    for (j = i; j >= gap && dList[j - gap] > temp; j -= gap)
                        dList[j] = dList[j - gap];

                    //Put temp where it belongs
                    dList[j] = temp;
                }
            }
            return 0;
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
        public static int ShellSort(List<Guid> gList)
        {
            int n = gList.Count;

            for (int gap = n / 2; gap > 0; gap /= 2)
            {

                for (int i = gap; i < n; i += 1)
                {
                    Guid temp = gList[i];


                    int j;
                    for (j = i; j >= gap &&  Guid1IsGreater(gList[j - gap], temp); j -= gap)
                        gList[j] = gList[j - gap];

                    gList[j] = temp;
                }
            }
            return 0;
        }
    }
}
