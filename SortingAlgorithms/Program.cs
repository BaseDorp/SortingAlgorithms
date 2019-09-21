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

            Console.WriteLine("Press enter to begin shell sort.");
            Console.ReadLine();
            //Sort.exampleShellSort(Sort.theDoubles, Sort.doublesListLength);
            Sort.ShellSort(Sort.theGuids);
            Console.WriteLine("Done sorting. Press enter to show sorted list.");
            Console.ReadLine();
            Sort.ShowElementsOfList(Sort.theGuids);
            Console.WriteLine("Done showing list. Press enter to exit program.");
            Console.ReadLine();


        }
    }
}
