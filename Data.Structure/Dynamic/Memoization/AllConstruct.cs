using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Structure.Dynamic.Memoization
{
    public static class AllConstruct
    {
        public static IList<IList<string>> G(string target, List<string> wordBank) => G(target, wordBank, new Dictionary<string, IList<IList<string>>>());

        private static IList<IList<string>> G(string target, List<string> wordBank, Dictionary<string, IList<IList<string>>> memo)
        {
            if (memo.TryGetValue(target, out var value))
                return value;

            if (target == string.Empty)
                return new List<IList<string>> { new List<string>() };

            if (target == null)
                return null;

            var result = new List<IList<string>>();

            foreach (var word in wordBank)
            {
                if (!target.StartsWith(word)) continue;

                var suffix = target[word.Length..];
                var suffixWays = G(suffix, wordBank, memo);

                var targetWays = suffixWays.Select(w =>
                {
                    w.Add(word);
                    return w;
                }).ToList();

                result.AddRange(targetWays);
            }

            memo.TryAdd(target, result);
            return result;
        }
    }
}