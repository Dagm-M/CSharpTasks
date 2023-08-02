using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {

        Console.WriteLine("Enter String:");

        string? inputString = Console.ReadLine();

        if (inputString != null)
        {
            Dictionary<string, int> wordFrequencies = WordFrequencyCounter.CalculateWordFrequency(inputString);

            foreach (var entry in wordFrequencies)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }
        else
        {
            Console.WriteLine("Invalid input");
        }
    }
}