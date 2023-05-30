using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Vector
{

    public class AscendingIntComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return A - B;
        }
    }

    class Tester
    {
        private static bool CheckAscending(Vector<int> vector)
        {
            for (int i = 0; i < vector.Count - 1; i++)
                if (vector[i] > vector[i + 1]) return false;
            return true;
        }

        static void Main(string[] args)
        {
            string result = "";
            int problem_size = 2048;
            int[] data = new int[problem_size]; data[0] = 333;
            Random k = new Random(1000);
            for (int i = 1; i < problem_size; i++) data[i] = 100 + k.Next(900);

            Vector<int> vector = null;
            Stopwatch watch = new Stopwatch();
            // ------------------ Tim Sort,Insertion Sort and MergeSort comparison on large data ----------------------------------

            try
            {
                
                Console.WriteLine("\nTest A: Sort integer numbers applying TimSort with the AscendingIntComparer on large data: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                watch.Restart();
                vector.Sort(new TimSort(),new AscendingIntComparer());
                watch.Stop();
                Console.WriteLine("Time elapsed: {0}", watch.Elapsed);
                watch.Reset();
                if (!CheckAscending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "A";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest B: Sort integer numbers applying InsertionSort with the AscendingIntComparer on large data: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                watch.Restart();
                vector.Sort(new InsertionSort(), new AscendingIntComparer());
                watch.Stop();
                Console.WriteLine("Time elapsed: {0}", watch.Elapsed);
                watch.Reset();
                if (!CheckAscending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "B";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest C: Sort integer numbers applying MergeSort with the AscendingIntComparer on large data: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                watch.Restart();
                vector.Sort(new MergeSortTopDown(), new AscendingIntComparer());
                watch.Stop();
                Console.WriteLine("Time elapsed: {0}", watch.Elapsed);
                watch.Reset();
                if (!CheckAscending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "C";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }
            // ------------------ Tim Sort,Insertion Sort and MergeSort comparison on small data ----------------------------------
            problem_size = 32;
            try
            {

                Console.WriteLine("\nTest D: Sort integer numbers applying TimSort with the AscendingIntComparer on small data: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                watch.Restart();
                vector.Sort(new TimSort(), new AscendingIntComparer());
                watch.Stop();
                Console.WriteLine("Time elapsed: {0}", watch.Elapsed);
                watch.Reset();
                if (!CheckAscending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "D";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest E: Sort integer numbers applying InsertionSort with the AscendingIntComparer on small data: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                watch.Restart();
                vector.Sort(new InsertionSort(), new AscendingIntComparer());
                watch.Stop();
                Console.WriteLine("Time elapsed: {0}", watch.Elapsed);
                watch.Reset();
                if (!CheckAscending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "E";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest F: Sort integer numbers applying MergeSort with the AscendingIntComparer on small data: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                watch.Restart();
                vector.Sort(new MergeSortTopDown(), new AscendingIntComparer());
                watch.Stop();
                Console.WriteLine("Time elapsed: {0}", watch.Elapsed);
                watch.Reset();
                if (!CheckAscending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "F";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            Console.WriteLine("\n\n ------------------- SUMMARY ------------------- ");
            Console.WriteLine("Tests passed: " + result);
            Console.ReadKey();
        }

    }
}
