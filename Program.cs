using System;
using System.Collections.Generic;
class InvalidNumber : Exception
{
    public InvalidNumber(string message) : base(message)
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        const int arraySize = 10;
        int[] validNumbers = new int[arraySize];
        int currentIndex = 0;
        List<string> invalidInputs = new List<string>();

        for (int a = 0; a < arraySize; a++)
        {
            Console.Write($"Enter a number between 1 and 100: ");
            String input = Console.ReadLine();

            try
            {
                if (int.TryParse(input, out int number) && number >= 1 && number <= 100)
                {
                    validNumbers[currentIndex] = number;
                    currentIndex++;
                }
                else
                {
                    throw new InvalidNumber($"Invalid input: {input}. Please enter a number between 1 and 100.");
                }
            }
            catch (InvalidNumber ex)
            {
                Console.WriteLine(ex.Message);
                invalidInputs.Add(input);
                a--;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        Console.WriteLine("\n   Valid Numbers:\n*************************");
        for (int a = 0; a < currentIndex; a++)
        {
            Console.WriteLine($"Number {a + 1}: {validNumbers[a]}");
        }

        Console.WriteLine("\n   Invalid Numbers:\n***********************");
        foreach (var invalidInput in invalidInputs)
        {
            Console.WriteLine(invalidInput);
        }
    }
}