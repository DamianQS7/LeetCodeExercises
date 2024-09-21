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

    /// <summary>
    /// Best performance
    /// </summary>
    /// <param name="candies"></param>
    /// <param name="extraCandies"></param>
    /// <returns></returns>
    public static IList<bool> KidsWithCandiesUsingLINQ(int[] candies, int extraCandies) =>
        candies.Select(x => x + extraCandies >= candies.Max()).ToList();

    /// <summary>
    /// Very slow performance
    /// </summary>
    /// <param name="candies"></param>
    /// <param name="extraCandies"></param>
    /// <returns></returns>
    public static IList<bool> KidsWithCandiesNoLINQ(int[] candies, int extraCandies)
    {
        bool[] result = new bool[candies.Length];
        int max = 0;

        for (int x = 0; x < candies.Length; x++)
        {
            if (candies[x] > max)
                max = candies[x];
        }

        for (int i = 0; i < candies.Length; i++)
        {
            if (candies[i] + extraCandies >= max)
                result[i] = true;
            else
                result[i] = false;
                
        }

        return result;
    }
    
    /// <summary>
    /// Takeaway: If you are afraid of getting index out of bounds exception while checking the previous or later index
    /// in an array, you can add an index check before the condition you are aiming for
    /// </summary>
    /// <param name="flowerbed"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public static bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        for (int x = 0; x<flowerbed.Length; x++)
        {
            if (flowerbed[x] == 1)
                continue;

            if ((x - 1 >= 0 && flowerbed[x - 1] == 1) || (x + 1 < flowerbed.Length && flowerbed[x + 1] == 1))
                continue;
            else
                flowerbed[x] = 1;
                n--;
        }

        return n <= 0;
    }



    #endregion
}
