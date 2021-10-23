using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Structure
{
    public static class Utils
    {
        public static void Swap(int[] arr, int f, int s)
        {
            var temp = arr[f];
            arr[f] = arr[s];
            arr[s] = temp;
        }

        public static int FindMinIndex(int[] arr, int i)
        {
            var minIndex = i;
            for (var j = i; j < arr.Length; j++)
                if (arr[j] < arr[minIndex])
                    minIndex = j;

            return minIndex;
        }

        public static string LogArr(IEnumerable<int>? arr)
        {
            if (arr == null)
                return "";

            return string.Join(",", arr);
        }


        public static bool IsSortedACS<T>(IEnumerable<T> list) where T : IComparable<T>
        {
            var comparable = list as T[] ?? list.ToArray();
            var y = comparable.First();
            return comparable.Skip(1).All(x =>
            {
                var b = y.CompareTo(x) < 0;
                y = x;
                return b;
            });
        }

        public static bool IsSortsedDESC<T>(IEnumerable<T> list) where T : IComparable<T>
        {
            var comparable = list as T[] ?? list.ToArray();
            var y = comparable.First();
            return comparable.Skip(1).All(x =>
            {
                var b = y.CompareTo(x) > 0;
                y = x;
                return b;
            });
        }

        public static bool ContainsAny(this string haystack, params string[] needles)
        {
            foreach (var needle in needles)
            {
                if (haystack.Contains(needle))
                    return true;
            }

            return false;
        }

        public static void LogArr(int[,] arr)
        {
            for (var row = 0; row < arr.Length; row++)
            {
                for (var col = 0; col < arr.Length; col++)
                    Console.WriteLine(arr[row, col]);
            }
        }
    }


    public static class Extensions
    {
        /// <summary>
        /// Get the string slice between the two indexes.
        /// Inclusive for start index, exclusive for end index.
        /// </summary>
        public static string Slice(this string source, int start, int end)
        {
            if (end < 0) // Keep this for negative end support
            {
                end = source.Length + end;
            }

            int len = end - start; // Calculate length
            return source.Substring(start, len); // Return Substring of length
        }

        public static Func<T1, T3> Compose<T1, T2, T3>(this Func<T1, T2> f, Func<T2, T3> g)
        {
            return (x) => g(f(x));
        }
    }
}