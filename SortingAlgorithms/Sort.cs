using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Numerics;

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
        public static double[] doublesArray;

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
                    theInts.Add(Int32.Parse(values[2]));
                    theGuids.Add(Guid.Parse(values[1]));
                    theDoubles.Add(Double.Parse(values[2]));

                    guidsListLength = theGuids.Count;
                    doublesListLength = theDoubles.Count;
                }
                doublesArray = theDoubles.ToArray();
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
        public static void ShowElementsOfList(List<int> d)
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
        /// Justin's Bucket Sorts
        /// </summary>
        /// <param name="theData"></param>
        /// <returns></returns>
        public static List<Guid> BucketSort(List<Guid> theData)
        {
            return new List<Guid>();
        }

        public static List<double> BucketSort(List<double> theData)
        {
            List<double> result = new List<double>();

            int numOfBuckets = 10;

            List<double>[] buckets = new List<double>[numOfBuckets];
            for(int i = 0; i < numOfBuckets; i++)
            {
                buckets[i] = new List<double>();
            }

            for(int i = 0; i < theData.Count; i++)
            {
                int bucketChoice = (int)(theData[i] / numOfBuckets);
                buckets[bucketChoice].Add(theData[i]);
            }

            for(int i = 0; i < numOfBuckets; i ++)
            {
                double[] temp = BubbleSort(buckets[i]);
                result.AddRange(temp);
            }
            return result;
        }

        public static double[] BubbleSort(List<double> input)//used in bucket sort
        {
            for(int i = 0; i < input.Count; i++)
            {
                for(int j = 0; j < input.Count; j++)
                {
                    if (input[i] < input[j])
                    {
                        double temp = input[i];
                        input[i] = input[j];
                        input[j] = temp;
                    }
                }
            }
            return input.ToArray();
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

        public static void ShellSort(List<Double> dList)//Time complexity: O(N^2). Gap size is reduced by half every iteration. too few gaps slow down the passes, and too many gaps produces overhead
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
        }

        public static void ShellSort(List<Guid> gList)
        {
            int n = gList.Count;

            for (int gap = n / 2; gap > 0; gap /= 2)
            {

                for (int i = gap; i < n; i += 1)
                {
                    Guid temp = gList[i];


                    int j;
                    for (j = i; j >= gap && Guid1IsGreaterUsingLong(gList[j - gap], temp); j -= gap)
                        gList[j] = gList[j - gap];

                    gList[j] = temp;
                }
            }
        }
        /// <summary>
        /// This version of guid comparison uses GuidToBigInt, which uses Guid.ToByteArray
        /// </summary>
        public static bool Guid1IsGreater(Guid guid1, Guid guid2)
        {
            BigInteger bigInt1 = GuidToBigInt(guid1);
            BigInteger bigInt2 = GuidToBigInt(guid2);
            if (bigInt1 > bigInt2)
                return true;
            else
                return false;
        }
        /// <summary>
        /// This version of guid comparison uses GuidToLong, which separates the guid via its delimiters, converts each part of the guid to a long, and sums them to compare the final values
        /// </summary>
        public static bool Guid1IsGreaterUsingLong(Guid guid1, Guid guid2)
        {
            long long1 = GuidToLong(guid1);
            long long2 = GuidToLong(guid2);
            if (long1 > long2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static BigInteger GuidToBigInt(Guid g)
        {
            BigInteger bigInt = new BigInteger(g.ToByteArray());
            return bigInt;
        }

        public static long GuidToLong(Guid g)
        {
            var line = g.ToString();
            var values = line.Split('-');
            var part1 = long.Parse(values[0], System.Globalization.NumberStyles.HexNumber);
            var part2 = long.Parse(values[1], System.Globalization.NumberStyles.HexNumber);
            var part3 = long.Parse(values[2], System.Globalization.NumberStyles.HexNumber);
            var part4 = long.Parse(values[3], System.Globalization.NumberStyles.HexNumber);
            var part5 = long.Parse(values[4], System.Globalization.NumberStyles.HexNumber);

            long totalValue = part1 + part2 + part3 + part4 + part5;

            return totalValue;
        }
    }
}
