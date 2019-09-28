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
                    theInts.Add(Int32.Parse(values[0]));
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
        public static void ShowElementsOfList(List<Guid> g)
        {
            foreach (var element in g)
            {
                Console.Write(element + " ");
            }
            Console.Write("\n");
        }

        /////////////////////////////////////////////
        /// Functions used in bucket sort


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

        public static void Scatter(double[] array, List<List<double>> buckets)
        {
            foreach (double value in array)
            {
                int bucketNumber = GetBucketNumber(value);
                buckets[bucketNumber].Add(value);
            }
        }

        public static void InsertionSort(double[] array)
        {
            int j;
            double temp;

            for (int i = 1; i < array.Length; i++)
            {
                j = i;
                while (j > 0 && array[j] < array[j - 1])
                {
                    temp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temp;
                    j--;
                }
            }
        }

        public static int GetBucketNumber(double value)
        {
            double val = value % 10;
            int bucketNumber = (int)Math.Floor(val);
            return bucketNumber;
        }

        public static void InitializeBuckets(List<List<double>> buckets)
        {
            for (int i = 0; i < 10; i++)
            {
                List<double> a = new List<double>();
                buckets.Add(a);
            }
        }
        
        ///////////////////////////////////////////////////////////

        /// <summary>
        /// Justin's Bucket Sorts
        /// </summary>
        /// <param name="theData"></param>
        /// <returns></returns>
        public static List<Guid> BucketSort(List<Guid> theData)
        {
            return new List<Guid>();
        }
        public static double[] BucketSort(double[] array)
        {
            List<List<double>> buckets = new List<List<double>>();
            InitializeBuckets(buckets);

            Scatter(array, buckets);

            int i = 0;
            foreach (List<double> bucket in buckets)
            {
                double[] arr = bucket.ToArray();
                InsertionSort(arr);

                foreach (double d in arr)
                {
                    array[i++] = d;
                }
            }

            return array;
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
        /// <summary>
        /// For the sake of comparing guids, this function returns true when the first guid is greater than the second, determined by turning the Guids into BigInts and comparing those values
        /// </summary>
        static bool Guid1IsGreater(Guid guid1, Guid guid2)//alternative method: split guid into string substrings, parseint, do what CompareTo does
        {
            BigInteger bigInt1 = GuidToBigInt(guid1);
            BigInteger bigInt2 = GuidToBigInt(guid2);
            if (bigInt1 > bigInt2)
                return true;
            else
                return false;
        }

        static BigInteger GuidToBigInt(Guid g)
        {
            BigInteger bigInt = new BigInteger(g.ToByteArray());
            return bigInt;
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
                    for (j = i; j >= gap &&  Guid1IsGreater(gList[j - gap], temp); j -= gap)
                        gList[j] = gList[j - gap];

                    gList[j] = temp;
                }
            }
        }
    }
}
