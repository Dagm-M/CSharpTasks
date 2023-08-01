using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {

        Console.WriteLine("Enter String:");

        string inputString = Console.ReadLine();

        Dictionary<string, int> wordFrequencies = WordFrequencyCounter.CalculateWordFrequency(inputString);

        foreach (var entry in wordFrequencies)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }
}