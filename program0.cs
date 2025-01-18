using System;
using System.Collections.Generic;
using System.IO;

namespace CSharp_Lab_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1 and 2: Creating Variables and Input Validation
            int low = GetPositiveInput("Enter the low number (positive only): ");
            int high = GetValidHighNumber(low);

            Console.WriteLine($"The difference between {high} and {low} is: {high - low}");

            // Task 3: Using Arrays and File I/O
            List<int> numbers = CreateNumberList(low, high);
            WriteNumbersToFile(numbers, "numbers.txt");
            int sum = ReadAndSumNumbersFromFile("numbers.txt");
            Console.WriteLine($"The sum of the numbers in the file is: {sum}");

            // Task 4: Prime Numbers
            Console.WriteLine("Prime numbers between {low} and {high}:");
            foreach (var number in numbers)
            {
                if (IsPrime(number))
                {
                    Console.WriteLine(number);
                }
            }
        }

        // Method to get a positive input
        static int GetPositiveInput(string prompt)
        {
            int value;
            do
            {
                Console.Write(prompt);
            } while (!int.TryParse(Console.ReadLine(), out value) || value <= 0);
            return value;
        }

        // Method to get a high number greater than the low number
        static int GetValidHighNumber(int low)
        {
            int high;
            do
            {
                Console.Write("Enter a high number (greater than the low number): ");
            } while (!int.TryParse(Console.ReadLine(), out high) || high <= low);
            return high;
        }

        // Method to create a list of numbers between low and high
        static List<int> CreateNumberList(int low, int high)
        {
            List<int> numbers = new List<int>();
            for (int i = low; i <= high; i++)
            {
                numbers.Add(i);
            }
            return numbers;
        }

        // Method to write numbers to a file in reverse order
        static void WriteNumbersToFile(List<int> numbers, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                for (int i = numbers.Count - 1; i >= 0; i--)
                {
                    writer.WriteLine(numbers[i]);
                }
            }
            Console.WriteLine($"Numbers written to {fileName}.");
        }

        // Method to read numbers from a file and calculate their sum
        static int ReadAndSumNumbersFromFile(string fileName)
        {
            int sum = 0;
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (int.TryParse(line, out int number))
                    {
                        sum += number;
                    }
                }
            }
            return sum;
        }

        // Method to check if a number is prime
        static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
