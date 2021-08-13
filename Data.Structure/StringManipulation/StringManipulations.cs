using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Data.Structure.StringManipulation
{
    public class StringManipulations
    {
        const int ASCII_MAXSIZE = 256;
        const int EN_Chars_MAXSIZE = 26;

        public static int GetVowelCount(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return 0;

            var vowels = new HashSet<char> {'A', 'E', 'O', 'U', 'I'};

            return str.Count(ch => vowels.Contains(char.ToUpper(ch)));
        }

        public static string ReverseString(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return "";

            var rev = new StringBuilder();
            for (var i = str.Length - 1; i >= 0; i--) rev.Append(str[i]);

            return rev.ToString();
        }

        public static string ReverseOrderOfWords(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return "";

            // 1 option
            return string.Join(' ', str.Trim().Split(' ').Reverse());

            // 2 option
            // var wordsRev = new StringBuilder();
            //
            // for (var i = words.Length - 1; i >= 0; i--)
            //     wordsRev.Append(words[i] + " ");
            //
            // return wordsRev.ToString().Trim();
        }

        public static bool IsRotationOfAnotherString(string str1, string str2)
        {
            return str1?.Length == str2?.Length && (str1 + str1).Contains(str2);
        }

        public static string RemoveDuplicatesChars(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return "";

            var strSet = new HashSet<char>();
            var output = new StringBuilder();

            foreach (var ch in str.Where(ch => !strSet.Contains(ch)))
            {
                strSet.Add(ch);
                output.Append(ch);
            }

            return output.ToString();
        }

        public static char MostRepeatedChar(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return ' ';

            // option 1
            var frequencies = new int[ASCII_MAXSIZE];

            foreach (var ch in str)
                frequencies[ch]++;

            var max = 0;
            var maxChar = ' ';

            for (var index = 0; index < frequencies.Length; index++)
            {
                var frequency = frequencies[index];
                if (frequency <= max) continue;

                max = frequency;
                maxChar = (char) index;
            }

            return maxChar;

            // option 2
            // var frequencies = new Dictionary<char, int>();
            //
            // foreach (var ch in str.Where(ch => !frequencies.TryAdd(ch, 0)))
            //    frequencies[ch]++;
            //
            // return frequencies.FirstOrDefault(x => x.Value == frequencies.Values.Max()).Key;
        }

        public static string CapitalizeFirstLetterOfEachWord(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return "";

            const RegexOptions options = RegexOptions.None;
            var regex = new Regex("[ ]{2,}", options);
            var words = regex.Replace(str.Trim(), " ").Split(" ");

            var i = 0;

            for (; i < words.Length; i++)
                words[i] = words[i][..1].ToUpper() + words[i][1..];

            return string.Join(' ', words);
        }

        public static bool StringsAreAnagram(string str1, string str2)
        {
            if (str1?.Length != str2?.Length || string.IsNullOrWhiteSpace(str1) || string.IsNullOrWhiteSpace(str2))
                return false;

            // option 1
            // return str1.All(str2.Contains);

            // option 2
            // var str1Chars = str1.ToCharArray();
            // Array.Sort(str1Chars);
            //
            // var str2Chars = str2.ToCharArray();
            // Array.Sort(str2Chars);
            //
            // return str1Chars.SequenceEqual(str2Chars);

            // option 3
            var frequencies = new int[EN_Chars_MAXSIZE];
            str1 = str1.ToLower();
            foreach (var c in str1)
                frequencies[c - 'a']++;

            str2 = str2.ToLower();

            foreach (var c in str2)
            {
                var index = c - 'a';
                if (frequencies[index] == 0)
                    return false;

                frequencies[index]--;
            }

            return true;
        }

        public static bool StringIsPalindrome(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;
            
            // option 1 4 time loops
            // var input = new StringBuilder(str);
            // return input.ToString().Reverse().SequenceEqual(str);

            // option 2
            var start = 0;
            var end = str.Length - 1;

            while (start <= end)
            {
                if (str[start++] != str[end--])
                    return false;
            }

            return true;
        }
    }
}