namespace BIO2021;

// Pat: Can be split into two parts:
// - Each part is min one char long
// - Left part only contains chars later in the alphabet
// - Both parts are reverse Pats

public static class Q1DownPat
{
    public static void PartA()
    {
        Console.Write("Input: ");
        string rawString = Console.ReadLine()!.ToUpper();
        string[] words = rawString.Split(' ');

        string first = words[0];
        string second = words[1];
        string third = first + second;
        
        Console.WriteLine(CheckPat(first) ? "YES" : "NO");
        Console.WriteLine(CheckPat(second) ? "YES" : "NO");
        Console.WriteLine(CheckPat(third) ? "YES" : "NO");
    }

    public static void PartB()
    {
        string input = "ABCD";
        List<char> temp = [];
        for (int one = 0; one < 4; one++)
        {
            temp.Add(input[one]);
            for (int two = 0; two < 3; two++)
            {
                temp.Add(input[two]);
            }
        }
    }
    
    private static bool CheckPat(string input)
    {
        switch (input.Length)
        {
            case 1:
                return true;
            case 2:
                return IsPat(input[0].ToString(), input[1].ToString());
            case > 2:
                (string left, string right) = Split(input);
                return (CheckPat(left) && CheckPat(right));
            default:
                return false;
        }
    }
    
    private static (string, string) Split(string input)
    {
        for (int index = 0; index < input.Length; index++)
        {
            string left = input[..index];
            string right = input[index..];
            
            if (IsPat(left, right))
            {
                string leftRev = left.Aggregate("", (current, c) => c + current);
                string rightRev = right.Aggregate("", (current, c) => c + current);
                return (leftRev, rightRev);
            }
        }
        
        return ("", "");
    }
    
    private static bool IsPat(string left, string right)
    {
        int[] leftValues = left.Select(c => (int)c).ToArray();
        int[] rightValues = right.Select(c => (int)c).ToArray();

        if (leftValues.Length < 1 || rightValues.Length < 1)
            return false;
        
        foreach (int leftCode in leftValues)
        {
            foreach (int rightCode in rightValues)
            {
                if (leftCode < rightCode)
                {
                    return false;
                }
            }
        }
        return true;
    }
}