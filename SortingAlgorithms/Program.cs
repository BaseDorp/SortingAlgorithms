using System;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Sort.FileReader();
            Console.WriteLine("Finished reading.");
            Console.WriteLine(Sort.theInts[999999] + "," + Sort.theGuids[999999] + "," + Sort.theDoubles[999999]);//testing to make sure it can tell us the final line of the CSV

            Console.WriteLine("Shell Sort:");
            Sort.exampleShellSort(Sort.theDoubles, Sort.doublesListLength);
            Sort.ShowElementsOfList(Sort.theDoubles);

            Console.WriteLine("Done.");
            Console.Read();


        }
    }
}
