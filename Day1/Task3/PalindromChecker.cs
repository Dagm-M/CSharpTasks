using System;
using System.Text.RegularExpressions;

public class PalindromeChecker
{
    public static bool IsPalindrome(string input)
    {
        string cleanInput = Regex.Replace(input, @"[\p{P}\s]", "").ToLower();

        int left = 0;
        int right = cleanInput.Length - 1;

        while (left < right)
        {
            if (cleanInput[left] != cleanInput[right])
            {
                return false;
            }
            left++;
            right--;
        }

        return true;
    }
}