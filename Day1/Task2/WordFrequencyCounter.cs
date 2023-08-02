using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class WordFrequencyCounter
{
    public static Dictionary<string, int> CalculateWordFrequency(string input)
    {

        string cleanInput = Regex.Replace(input, @"[\p{P}\p{S}]", "");

        string[] words = cleanInput.ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


        Dictionary<string, int> wordFrequencyDict = new Dictionary<string, int>();

        // Count the frequency of each word
        foreach (string word in words)
        {
            if (wordFrequencyDict.ContainsKey(word))
            {
                wordFrequencyDict[word]++;
            }
            else
            {
                wordFrequencyDict[word] = 1;
            }
        }

        return wordFrequencyDict;
    }
}
