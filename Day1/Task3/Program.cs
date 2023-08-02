using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter String:");

        string? inputString = Console.ReadLine();

        if (inputString != null)
        {
            bool isPalindrome = PalindromeChecker.IsPalindrome(inputString);

            if (isPalindrome)
            {
                Console.WriteLine($"your output is a palindrom");
            }
            else
            {
                Console.WriteLine($"your output is not a palindrom");
            }
        }
        else
        {
            Console.WriteLine("Invalid input");
        }
    }
}
