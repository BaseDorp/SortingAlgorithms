using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;

namespace SortingAlgorithms
{
    class Sort
    {
        public static List<int> theInts = new List<int>();
        public static List<Guid> theGuids = new List<Guid>();
        public static List<Double> theDoubles = new List<Double>();

<<<<<<< HEAD
        public static int guidsListLength;
        public static int doublesListLength;
        
=======
        List<double> TestDoubles = new List<double> {1,4,5,8,2,10};

        public static int guidsListLength;
        public static int doublesListLength;

        public static string filePath = "C:\\CSVfolder\\jb.csv";
        //Sam's filepath: "D:\C#Projects\Algorithms\SortingAlgorithms\SortingAlgorithms\SortingAlgorithms\bin\Debug\netcoreapp2.1\jb.csv"
>>>>>>> 947f5205d339480cb4e43cf6b57c4530960310ea

        /// <summary>
        /// Splits the CSV, putting each of the items into the appropriate list. you can then reference them using, for example, Sort.theInts[999999] to find the final int
        /// </summary>
        public static void FileReader()
        {
<<<<<<< HEAD
            // Sets the filepath that reads the data from \SortingAlgorithms\bin\Debug\netcoreapp2.1\Data.csv
            string filePath = Directory.GetCurrentDirectory() + @"\Data.csv";
=======
>>>>>>> 947f5205d339480cb4e43cf6b57c4530960310ea
            using (var streamReader = new StreamReader(@filePath))
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

        // User Interface ----------------------------------------------------------------------------------
        public Sort()
        {
            FileReader();
            int input = 0;
            do
            {
                Console.WriteLine("Please select the type of sort you would like to do. (Enter 1-4)");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. Selection Sort\n2. Bubble Sort\n3. Bucket Sort\n4. Shell Sort");
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
                    BucketSort(theGuids);
                    BucketSort(theDoubles);
                    break;
                case 4:
                    ShellSort(theGuids);
                    ShellSort(theDoubles);
                    break;
            }
        }



        /// <summary>
<<<<<<< HEAD
        /// Bucket Sort -------------------------------------------------------------------------------------------
        /// <see cref="https://www.csharpstar.com/csharp-program-to-perform-bucket-sort/"/>
        /// <see cref="https://exceptionnotfound.net/bucket-sort-csharp-the-sorting-algorithm-family-reunion/"/>
        /// </summary>
        /// <param name="theData">Instance of the list of Guids</param>
=======
        /// Justin's Bucket Sorts
        /// <see cref="https://www.csharpstar.com/csharp-program-to-perform-bucket-sort/"/>
        /// <see cref="https://exceptionnotfound.net/bucket-sort-csharp-the-sorting-algorithm-family-reunion/"/>
        /// </summary>
        /// <param name="theData"></param>
>>>>>>> 947f5205d339480cb4e43cf6b57c4530960310ea
        /// <returns></returns>
        public static void BucketSort(List<Guid> theData)
        {
            List<Guid> result = new List<Guid>();

            int numOfBuckets = 1000;

            Console.WriteLine("Sorting guids using bucket sort with " + numOfBuckets + " buckets...");
            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<Guid>[] buckets = new List<Guid>[numOfBuckets];
            for (int i = 0; i < numOfBuckets; i++)
            {
                buckets[i] = new List<Guid>();
            }

            for (int i = 0; i < theData.Count; i++)
            {
                int bucketChoice = (int)(Math.Abs(GuidFirstSectionToInt(theData[i]) % numOfBuckets));
                buckets[bucketChoice].Add(theData[i]);
            }

            for (int i = 0; i < numOfBuckets; i++)
            {
                Guid[] temp = BubbleSortForBucket(buckets[i]);
                result.AddRange(temp);
            }

            watch.Stop();
            ShowElementsOfList(result);
            Console.WriteLine("Done! Shell sort took " + watch.ElapsedMilliseconds / 1000 + " seconds.");
        }

        public static Guid[] BubbleSortForBucket(List<Guid> input)//used in bucket sort
        {
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input.Count; j++)
                {
                    if (Guid1IsGreater(input[j], input[i]))
                    {
                        Guid temp = input[i];
                        input[i] = input[j];
                        input[j] = temp;
                    }
                }
            }
            return input.ToArray();
        }

        public static void BucketSort(List<double> theData)
        {
            List<double> result = new List<double>();

            int numOfBuckets = 1000;

            Console.WriteLine("Sorting doubles using bucket sort with " + numOfBuckets + " buckets...");
            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<double>[] buckets = new List<double>[numOfBuckets];
            for (int i = 0; i < numOfBuckets; i++)
            {
                buckets[i] = new List<double>();
            }

            for (int i = 0; i < theData.Count; i++)
            {
                int bucketChoice = (int)(theData[i] % numOfBuckets);
                buckets[bucketChoice].Add(theData[i]);
            }

            for (int i = 0; i < numOfBuckets; i++)
            {
                double[] temp = BubbleSortForBucket(buckets[i]);
                result.AddRange(temp);
            }
<<<<<<< HEAD
            
=======
>>>>>>> 947f5205d339480cb4e43cf6b57c4530960310ea
            watch.Stop();
            ShowElementsOfList(result);
            Console.WriteLine("Done! Shell sort took " + watch.ElapsedMilliseconds / 1000 + " seconds.");
        }

        public static double[] BubbleSortForBucket(List<double> input)//used in bucket sort
        {
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input.Count; j++)
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
<<<<<<< HEAD
        
        /// <summary>
        /// Shell Sort ---------------------------------------------------------------------------------------------
        /// Currently implemented shell sort is a total cut and paste, just to examine functionality!
=======

        public static int GuidFirstSectionToInt(Guid g)//returns only the first delimited section of the guid as an int, used to decide which bucket to place the guids into when bucket sorting
        {
            var line = g.ToString();
            var values = line.Split('-');
            var part1 = int.Parse(values[0], System.Globalization.NumberStyles.HexNumber);

            return part1;
        }

        /// <summary>
        /// Justin's Shell Sorts
>>>>>>> 947f5205d339480cb4e43cf6b57c4530960310ea
        /// <see cref="https://www.tutorialspoint.com/shell-sort-program-in-chash"/>
        /// <see cref="https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-1.php"/>
        /// <see cref="https://www.geeksforgeeks.org/shellsort/"/>
        /// </summary>
        /// <param name="theData"></param>
        /// <returns></returns>
<<<<<<< HEAD
=======
        /// 

>>>>>>> 947f5205d339480cb4e43cf6b57c4530960310ea
        public static void ShellSort(List<Double> dList)//Time complexity: O(N^2). Gap size is reduced by half every iteration. too few gaps slow down the passes, and too many gaps produces overhead
        {
            int n = dList.Count;//n is the size of our list
            Console.WriteLine("Sorting doubles using shell sort...");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            //Sort using large gaps, and reduce gap size gradually
            for (int gap = n / 2; gap > 0; gap /= 2)//our gap sizes will be 500k, then 250k, then 125k, etc...
            {
                Console.WriteLine("Current gap being sorted: " + gap);
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
            watch.Stop();
            ShowElementsOfList(theDoubles);
            Console.WriteLine("Done! Shell sort took " + watch.ElapsedMilliseconds / 1000 + " seconds.");
        }

        public static void ShellSort(List<Guid> gList)
        {
            int n = gList.Count;

            Console.WriteLine("Sorting guids using shell sort...");
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                Console.WriteLine("Current gap being sorted: " + gap);

                for (int i = gap; i < n; i += 1)
                {
                    Guid temp = gList[i];


                    int j;
                    for (j = i; j >= gap && Guid1IsGreaterUsingLong(gList[j - gap], temp); j -= gap)
                        gList[j] = gList[j - gap];

                    gList[j] = temp;
                }
            }
            watch.Stop();
            ShowElementsOfList(theGuids);
            Console.WriteLine("Done! Shell sort took " + watch.ElapsedMilliseconds / 1000 + " seconds.");
        }
<<<<<<< HEAD
        
        // Guid Sorting Methods ---------------------------------------------------------------------------------------
        public static int GuidFirstSectionToInt(Guid g)//returns only the first delimited section of the guid as an int, used to decide which bucket to place the guids into when bucket sorting
        {
            var line = g.ToString();
            var values = line.Split('-');
            var part1 = int.Parse(values[0], System.Globalization.NumberStyles.HexNumber);

            return part1;
        }

=======
>>>>>>> 947f5205d339480cb4e43cf6b57c4530960310ea
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
<<<<<<< HEAD

=======
>>>>>>> 947f5205d339480cb4e43cf6b57c4530960310ea
        /// <summary>
        /// This version of guid comparison uses GuidToLong, which separates the guid via its delimiters, converts each part of the guid to a long, and sums them to compare the final values
        /// This function isn't actively used anywhere, but I added it in case the GuidToBigInt's use of Guid.ToByteArray was considered too much of an 'easy solution'
        /// Any function using Guid1IsGreater should be able to substitute Guid1IsGreaterUsingLong and achieve similar results
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

        static BigInteger GuidToBigInt(Guid g)//turns a guid into a big integer for comparison in Guid1IsGreater
        {
            BigInteger bigInt = new BigInteger(g.ToByteArray());
            return bigInt;
        }

        public static long GuidToLong(Guid g)//separates each delimited section of the guid into longs and sums their values, for use in Guid1IsGreaterUsingLong
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


        /// <summary>
<<<<<<< HEAD
        /// Bubble Sort ----------------------------------------------------------------------------------------------
=======
        /// Bubble Sort Method: Jared Bronstein ---------------------------------------------
>>>>>>> 947f5205d339480cb4e43cf6b57c4530960310ea
        /// References
        /// <see cref="https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-3.php"/>
        /// <see cref="https://www.geeksforgeeks.org/bubble-sort/"/>
        /// <see cref="https://www.c-sharpcorner.com/UploadFile/3d39b4/bubble-sort-in-C-Sharp/"/>
        /// </summary>
        /// <param name="theData">The list of Guids or Doubles provided by the CSV file</param>
        /// <returns>The sorted list of the CSV file data</returns>
        public static void BubbleSort(List<Guid> theData)
        {
            Console.WriteLine("Sorting guids using bubble sort...");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Guid b;
            for (int s = 0; s <= theData.Count - 2; s++)
            {
                for (int r = 0; r <= theData.Count - 2; r++)
                {
                    if (Guid1IsGreater(theData[r], theData[r + 1]))
                    {
<<<<<<< HEAD
                        b = theData[r + 1];
=======
                        b = theData[r+1];
>>>>>>> 947f5205d339480cb4e43cf6b57c4530960310ea
                        theData[r + 1] = theData[r];
                        theData[r] = b;
                    }
                }
<<<<<<< HEAD
                Console.WriteLine("{0}. {1}", s, theData[s]);
=======
>>>>>>> 947f5205d339480cb4e43cf6b57c4530960310ea
            }
            watch.Stop();
            ShowElementsOfList(theData);
            Console.WriteLine("Done! Bubble sort took " + watch.ElapsedMilliseconds / 1000 + " seconds.");
        }
        public static void BubbleSort(List<double> theData)
        {
            Console.WriteLine("Sorting...");
            var watch = System.Diagnostics.Stopwatch.StartNew();
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
<<<<<<< HEAD
                Console.WriteLine("{0}. {1}", s, theData[s]);
=======
>>>>>>> 947f5205d339480cb4e43cf6b57c4530960310ea
            }
            watch.Stop();
            ShowElementsOfList(theData);
            Console.WriteLine("Done! Bubble sort took " + watch.ElapsedMilliseconds / 1000 + " seconds.");
        }


        // Selection Sort -------------------------------------------------------------------
        /// <summary>
        /// <see cref="https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-11.php"
<<<<<<< HEAD
        /// <see cref="https://exceptionnotfound.net/selection-sort-csharp-the-sorting-algorithm-family-reunion/"/>
=======
>>>>>>> 947f5205d339480cb4e43cf6b57c4530960310ea
        /// </summary>
        /// <param name="g"></param>
        void Selection(List<Guid> g)
        {
            Console.WriteLine("Sorting guids using selection sort...");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Guid temp;
            for (int i = 0; i < g.Count; i++)
            {
<<<<<<< HEAD
                for (int n = i + 1; n < g.Count; n++)
=======
                for (int n = i+1; n < g.Count; n++)
>>>>>>> 947f5205d339480cb4e43cf6b57c4530960310ea
                {
                    if (Guid1IsGreater(g[n], g[i]))
                    {
                        temp = g[i];
                        g[i] = g[n];
                        g[n] = temp;
                    }
                }
<<<<<<< HEAD
                Console.WriteLine("{0}. {1}", i, g[i]);
=======
>>>>>>> 947f5205d339480cb4e43cf6b57c4530960310ea
            }
            watch.Stop();
            ShowElementsOfList(theGuids);
            Console.WriteLine("Done! Selection sort took " + watch.ElapsedMilliseconds / 1000 + " seconds.");
        }

        void Selection(List<double> d)
        {
            double temp = 0;
            Console.WriteLine("Sorting doubles using selection sort...");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < d.Count; i++)
            {
<<<<<<< HEAD
                for (int n = i + 1; n < d.Count; n++)
=======
                for (int n = i+1; n < d.Count; n++)
>>>>>>> 947f5205d339480cb4e43cf6b57c4530960310ea
                {
                    if (d[n] < d[i])
                    {
                        temp = d[i];
                        d[i] = d[n];
                        d[n] = temp;
                    }
                }
<<<<<<< HEAD
                Console.WriteLine("{0}. {1}",i, d[i]);
=======
                // Console.WriteLine("{0}. {1}",i, d[i]);
>>>>>>> 947f5205d339480cb4e43cf6b57c4530960310ea
            }
            watch.Stop();
            ShowElementsOfList(theDoubles);
            Console.WriteLine("Done! Selection sort took " + watch.ElapsedMilliseconds / 1000 + " seconds.");
        }
<<<<<<< HEAD
=======


>>>>>>> 947f5205d339480cb4e43cf6b57c4530960310ea
    }
}