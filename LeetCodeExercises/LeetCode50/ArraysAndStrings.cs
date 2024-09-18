using System.Text;

namespace LeetCodeExercises.LeetCode50;

public static class ArraysAndStrings
{
    #region Easy

    /// <summary>
    /// Merge two words, by taking one character of each word at a time.
    /// </summary>
    /// <param name="word1">First word</param>
    /// <param name="word2">Second word</param>
    /// <returns>Merged word</returns>
    public static string MergeAlternately(string word1, string word2)
    {
        StringBuilder mergedWord = new();
        int x = 0;
        int y = 0;

        while (x < word1.Length || y < word2.Length)
        {
            if (x < word1.Length)
            {
                mergedWord.Append(word1[x]);
                x++;
            }

            if (y < word2.Length)
            {
                mergedWord.Append(word2[y]);
                y++;
            }
        }

        return mergedWord.ToString();
    }

    /// <summary>
    /// Using the Euclidean Algorithm to find the GCD
    /// </summary>
    /// <param name="str1"></param>
    /// <param name="str2"></param>
    /// <returns></returns>
    public static string GcdOfStrings(string str1, string str2) 
    {
        if(!(str1 + str2).Equals(str2 + str1)) return string.Empty;

        int remainder; 
        int gcd = str1.Length; 
        int gcd_candidate = str2.Length;

        while (gcd_candidate is not 0)
        {
            remainder = gcd % gcd_candidate;
            gcd = gcd_candidate;
            gcd_candidate = remainder;
        }

        return str2[0..gcd];
    }


    #endregion
}
