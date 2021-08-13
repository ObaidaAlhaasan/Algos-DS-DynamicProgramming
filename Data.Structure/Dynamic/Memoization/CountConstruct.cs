using System.Collections.Generic;

namespace Data.Structure.Dynamic.Memoization
{
    public static class CountConstruct
    {
        public static int G(string target, List<string> wordBank)
        {
            return G(target, wordBank, new Dictionary<string, int>());
        }

        private static int G(string target, List<string> wordBank, Dictionary<string, int> memo)
        {
            if (memo.TryGetValue(target, out var value))
                return value;

            if (target == string.Empty)
                return 1;

            if (target == null)
                return 0;

            var count = 0;
            foreach (var word in wordBank)
            {
                if (target.StartsWith(word))
                {
                    var sliced = target[word.Length..];
                    count += G(sliced, wordBank, memo);
                }
            }

            memo.TryAdd(target, count);
            return count;
        }
    }
}