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
                while(!streamReader.EndOfStream)
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
            foreach(var element in d)
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
        /// Justin's Radix Sorts
        /// </summary>
        /// <param name="theData"></param>
        /// <returns></returns>
        public static List<Guid> RadixSort(List<Guid> theData)
        {
            return new List<Guid>();
        }
        public static List<Double> RadixSort(List<Double> theData)
        {
            return new List<Double>();
        }

        /// <summary>
        /// Justin's Shell Sorts
        /// Currently implemented shell sort is a total cut and paste, just to examine functionality!
        /// From: <see cref="https://www.tutorialspoint.com/shell-sort-program-in-chash"/>
        /// From: <see cref="https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-1.php"/>
        /// </summary>
        /// <param name="theData"></param>
        /// <returns></returns>
        /// 
        public static void exampleShellSort(List<Double> arr, int list_length)
        {
            int i, j, inc, temp;
            inc = 3;
            while (inc > 0)
            {
                Console.WriteLine("A");
                for (i = 0; i < list_length; i++)
                {
                    Console.WriteLine(i);
                    j = i;
                    temp = (int)arr[i];
                    while ((j >= inc) && (arr[j - inc] > temp))
                    {
                        arr[j] = arr[j - inc];
                        j = j - inc;
                    }
                    arr[j] = temp;
                }
                if (inc / 2 != 0)
                    inc = inc / 2;
                else if (inc == 1)
                    inc = 0;
                else
                    inc = 1;
            }
        }
        public static List<Guid> ShellSort(List<Guid> theData)
        {
            return new List<Guid>();
        }
        public static List<Double> ShellSort(List<Double> theData)
        {
            return new List<Double>();
        }
    }
}
