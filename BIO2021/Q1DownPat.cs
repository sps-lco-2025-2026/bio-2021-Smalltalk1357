using System.Diagnostics;

namespace BIO2021;

// Pat: Can be split into two parts:
// - Each part is min one char long
// - Left part only contains chars later in the alphabet
// - Both parts are reverse Pats

public class Q1DownPat
{
    public static void Run()
    {
        Split("DE");
    }
    
    public static bool CheckPat(string input)
    {
        leftPat
        return true;
    }
    
    private static (string, string) Split(string input)
    {
        for (int index = 0; index < input.Length; index++)
        {
            string left = input[..index];
            string right = input[index..];
            
            if (IsPat(left, right))
            {
                return (left, right);
            }
        }
        
        return ("", "");
    }
    
    private static bool IsPat(string left, string right)
    {
        int[] leftValues = left.Select(c => (int)c).ToArray();
        int[] rightValues = right.Select(c => (int)c).ToArray();
        
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