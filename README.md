


### C# Solution - Various Algorithms
---
This repository contains a C# solution that implements and tests multiple algorithms. These algorithms cover various tasks such as identifying magic potions, finding duplicates in arrays, reformatting strings, and organizing books into identical sets.

## Features

1. **Magic Potion Identifier**  
   Determines if a given number is a perfect cube. It returns "YES" if the number is a perfect cube, otherwise "NO".

2. **Sneaky Outcomes**  
   Identifies duplicate elements in an array and returns them in a sorted order.

3. **Reformat String to Alternating Case**  
   Converts a given string into alternating uppercase and lowercase characters, where the first letter of the string is capitalized.

4. **Organizing Books into Identical Sets**  
   Checks if a collection of books (represented by integers) can be grouped into identical sets, based on their frequency. Returns "YES" if it is possible to group them, otherwise "NO".

## Code Explanation

### 1. Magic Potion Identifier
This function checks if a given number is a perfect cube. It calculates the cube root of the number and checks if cubing that value returns the original number.

**Method:**
```csharp
static string IsMagicalPotion(long power)
{
    long cubeRoot = (long)Math.Round(Math.Pow(power, 1.0 / 3));
    return (cubeRoot * cubeRoot * cubeRoot == power) ? "YES" : "NO";
}
```

### 2. Sneaky Outcomes
This function identifies duplicate values in an array and returns a list of the duplicates. It uses a HashSet to track values that have been seen already.

**Method:**
```csharp
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
```

### 3. Reformat String to Alternating Case
This function converts a string to an alternating case format. Letters alternate between uppercase and lowercase, while other characters remain unchanged.

**Method:**
```csharp
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
```

### 4. Organizing Books into Identical Sets
This function checks if a collection of books can be grouped into identical sets by determining the greatest common divisor (GCD) of the frequencies of each book. If the GCD is greater than 1, the books can be grouped.

**Method:**
```csharp
static string CanOrganizeBooks(int[] shelf)
{
    Dictionary<int, int> freq = new Dictionary<int, int>();

    foreach (int book in shelf)
        freq[book] = freq.GetValueOrDefault(book, 0) + 1;

    int gcd = freq.Values.Aggregate(GCD);
    return (gcd > 1) ? "YES" : "NO";
}

static int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);
```

## Testing

The program has several test cases to demonstrate how each function works:

- **Magic Potion Identifier**: Tests if a number is a perfect cube.
- **Sneaky Outcomes**: Tests identifying duplicates in arrays.
- **Reformat String to Alternating Case**: Tests converting a string to alternating case.
- **Organizing Books into Identical Sets**: Tests grouping books into identical sets based on their frequencies.

### Sample Output
```bash
Magic Potion Identifier:
YES
NO
NO

Sneaky Outcomes:
2, 3
4, 5

Reformat String to Alternating Case:
HeLlO wOrLd!
AbC123! xYz

Organizing Books into Identical Sets:
YES
YES
```

## Requirements

- .NET Core 3.1 or higher
- C# Programming Language

## Usage

Clone this repository and open the project in Visual Studio or any other C# compatible IDE.

To run the application, use the following command in the terminal:
```bash
dotnet run
```

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---
