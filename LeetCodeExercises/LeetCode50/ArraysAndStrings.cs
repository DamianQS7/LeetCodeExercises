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

    public static string ReverseVowels(string word)
    {
        char[] vowels = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];
        int x = 0;
        int y = word.Length -1;
        char[] lettersInWord = new char[word.Length];

        for(int i = 0; i < word.Length; i++)
            lettersInWord[i] = word[i];
        
        while(x < y)
        {
            if (!vowels.Contains(word[x]))
                x++;
            if (!vowels.Contains(word[y]))
                y--;
            
            if (vowels.Contains(word[x]) && vowels.Contains(word[y]))
            {
                lettersInWord[y] = word[x];
                lettersInWord[x] = word[y];
                x++;
                y--;
            }

        }

        return new String(lettersInWord);
    }

    #endregion

    #region Medium

    public static string ReverseWords(string s)
    {
        StringBuilder output = new();

        string[] words = s.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        for (int x = words.Length - 1; x >= 0; x--)
        {
            output.Append(words[x]);
            if (x > 0)
                output.Append(' ');
        }

        return output.ToString();
    }

    /// <summary>
    /// Using "Prefix and Suffix Products" Approach.
    /// This is doing all the stuff explicitly.
    /// We can do better using less array in an improved form of this algorithm.
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int[] ProductExceptSelf(int[] nums)
    {
        int[] suffix = new int[nums.Length];
        int[] prefix = new int[nums.Length];
        int[] output = new int[nums.Length];
        prefix[0] = 1;
        suffix[^1] = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            prefix[i] = prefix[i - 1] * nums[i - 1];
        }

        for (int j = nums.Length - 2; j >= 0; j--)
        {
            suffix[j] = suffix[j + 1] * nums[j + 1];
        }

        for (int x = 0; x < nums.Length; x++)
        {
            output[x] = prefix[x] * suffix[x];
        }

        return output;
    }

    /// <summary>
    /// This version is using the same principle, but instead of using multiple arrays explicitly,
    /// we are going to use a variable that holds the values we need for the second iteration.
    /// All the results will be computed within the same array that will be the output.
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int[] ProductExceptSelfImproved(int[] nums)
    {
        
        int[] output = new int[nums.Length];
        output[0] = 1;
        int right = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            output[i] = output[i - 1] * nums[i - 1];
        }

        for (int j = nums.Length - 1; j >= 0; j--)
        {
            output[j] = output[j] * right;
            right *= nums[j];
        }

        return output;
    }
    #endregion
}
