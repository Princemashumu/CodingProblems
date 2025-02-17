using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Test Magic Potion Identifier
        Console.WriteLine("Magic Potion Identifier:");
        Console.WriteLine(IsMagicalPotion(27)); // YES
        Console.WriteLine(IsMagicalPotion(30)); // NO
        Console.WriteLine(IsMagicalPotion(132651201231)); // Expected output?

        // Test Sneaky Outcomes
        Console.WriteLine("\nSneaky Outcomes:");
        int[] outcomes1 = { 0, 3, 2, 1, 3, 2 };
        int[] outcomes2 = { 7, 1, 5, 4, 3, 4, 6, 0, 9, 5, 8, 2 };
        Console.WriteLine(string.Join(", ", FindDuplicates(outcomes1))); // [2, 3]
        Console.WriteLine(string.Join(", ", FindDuplicates(outcomes2))); // [4, 5]

        // Test Reformat String to Alternating Case
        Console.WriteLine("\nReformat String to Alternating Case:");
        Console.WriteLine(ReformatString("hello world!")); // HeLlO wOrLd!
        Console.WriteLine(ReformatString("abc123! xyz")); // AbC123! xYz

        // Test Organizing Books into Identical Sets
        Console.WriteLine("\nOrganizing Books into Identical Sets:");
        int[] shelf1 = { 5, 5, 3, 3, 2, 2 };
        int[] shelf2 = { 1, 1, 1, 2, 2, 2, 3, 3, 3 };
        Console.WriteLine(CanOrganizeBooks(shelf1)); // YES
        Console.WriteLine(CanOrganizeBooks(shelf2)); // YES
    }

    // 1. Magic Potion Identifier
    static string IsMagicalPotion(long power)
    {
        long cubeRoot = (long)Math.Round(Math.Pow(power, 1.0 / 3));
        return (cubeRoot * cubeRoot * cubeRoot == power) ? "YES" : "NO";
    }

    // 2. Sneaky Outcomes
    static int[] FindDuplicates(int[] outcomes)
    {
        HashSet<int> seen = new HashSet<int>();
        List<int> duplicates = new List<int>();

        foreach (int num in outcomes)
        {
            if (!seen.Add(num))
                duplicates.Add(num);
        }
        return duplicates.ToArray();
    }

    // 3. Reformat String to Alternating Case
    static string ReformatString(string s)
    {
        char[] result = s.ToCharArray();
        int count = 0;

        for (int i = 0; i < result.Length; i++)
        {
            if (char.IsLetter(result[i]))
            {
                result[i] = (count % 2 == 0) ? char.ToUpper(result[i]) : char.ToLower(result[i]);
                count++;
            }
        }
        return new string(result);
    }

    // 4. Organizing Books into Identical Sets
    static string CanOrganizeBooks(int[] shelf)
    {
        Dictionary<int, int> freq = new Dictionary<int, int>();

        foreach (int book in shelf)
            freq[book] = freq.GetValueOrDefault(book, 0) + 1;

        int gcd = freq.Values.Aggregate(GCD);
        return (gcd > 1) ? "YES" : "NO";
    }

    static int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);
}
