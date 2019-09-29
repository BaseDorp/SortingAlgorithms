using System;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Sort.FileReader();
            Console.WriteLine("Finished reading file.");
            Console.WriteLine("Final int: " + Sort.theInts[999999] + "," + " final guid: " + Sort.theGuids[999999] + "," + " final double: " + Sort.theDoubles[999999]);//testing to make sure it can tell us the final line of the CSV
            Sort.Guid1IsGreaterUsingLong(Sort.theGuids[0], Sort.theGuids[1]);

            Console.WriteLine("Press enter to begin sort.");
            Console.ReadLine();
            //Sort.ShellSort(Sort.theGuids);
            //Sort.BucketSort(Sort.doublesArray);
            Sort.theDoubles = Sort.BucketSort(Sort.theDoubles);
            Console.WriteLine("Done sorting. Press enter to show sorted list.");
            Console.ReadLine();
            //Console.WriteLine("[{0}]", string.Join(", ", Sort.doublesArray));
            //Sort.ShowElementsOfList(Sort.theGuids);
            Sort.ShowElementsOfList(Sort.theDoubles);
            Console.WriteLine("Done showing list. Press enter to exit program.");
            Console.ReadLine();


        }
    }
}
