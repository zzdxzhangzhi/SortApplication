using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortApplication
{
    class Program
    {
        private const int MaxDisplayNumber = 10000;

        private static void displayNumbers(int[] numberList)
        {
            Console.WriteLine("The numbers are:");
            for (int i = 0; i < numberList.Length && i < MaxDisplayNumber; i++)
            {
                if ((i > 1) && (i % 20 == 0))
                    Console.WriteLine();

                Console.Write("{0,7}", numberList[i]);
            }
            Console.WriteLine();
        }

        private static void getRandomNumbers(int[] randomNumbers)
        {
            Random randNum = new Random();
            for (int i = 0; i < randomNumbers.Length; i++)
            {
                randomNumbers[i] = randNum.Next() % randomNumbers.Length;
            }
        }

        public static int[] getUnsortedNumbers()
        {
            Console.WriteLine("Please input the number of the integer you want to sort:");
            string inputNumber = Console.ReadLine();
            int intNumber = Convert.ToInt32(inputNumber);

            int[] unsortedNumbers = new int[intNumber];
            getRandomNumbers(unsortedNumbers);
            displayNumbers(unsortedNumbers);

            return unsortedNumbers;
        }

        public static void swap(int first, int second, int[] array)
        {
            int tempInt = array[first];
            array[first] = array[second];
            array[second] = tempInt;
        }

        public static void bubbleSort(int[] unsortedList)
        {
            bool needSwap = true;

            for (int i = 0; needSwap; i++)
            {
                needSwap = false;
                for (int j = 0; j < unsortedList.Length - i - 1; j++)
                {
                    if (unsortedList[j] > unsortedList[j + 1])
                    {
                        swap(j, j + 1, unsortedList);
                        needSwap = true;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int[] unsortedList = getUnsortedNumbers();
            int[] unsortedListCopy = (int[])unsortedList.Clone();

            Console.ReadLine();

            Console.WriteLine("Now begin using bubble sort method to sort, please wait ......");
            DateTime startTime = DateTime.Now;
            bubbleSort(unsortedList);
            DateTime endTime = DateTime.Now;
            displayNumbers(unsortedList);

            Console.WriteLine("MicroSeconds elapsed for bubble sorting an array of length {0} is: {1}", 
                unsortedList.Length, (endTime - startTime).Ticks / 10000);

            Console.ReadLine();

            Console.WriteLine("Now begin using .NET built-in sort method to sort, please wait ......");
            startTime = DateTime.Now;
            Array.Sort(unsortedListCopy);
            endTime = DateTime.Now;
            displayNumbers(unsortedListCopy);

            Console.WriteLine("MicroSeconds elapsed for built-in sorting an array of length {0} is: {1}",
                unsortedList.Length, (endTime - startTime).Ticks / 10000);
        }
    }
}
