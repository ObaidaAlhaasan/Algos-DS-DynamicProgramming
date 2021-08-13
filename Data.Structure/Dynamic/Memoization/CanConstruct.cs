using System;
using System.Collections.Generic;

namespace Data.Structure.Dynamic.Memoization
{
    public static class CanConstruct
    {
        public static bool G(string target, IList<string> wordBank)
        {
            return G(target, wordBank, new Dictionary<string, bool>());
        }

        private static bool G(string target, IList<string> wordBank, Dictionary<string, bool> memo)
        {
            if (memo.TryGetValue(target, out var value))
                return value;
            
            if (target == "")
                return true;

            if (target == null)
                return false;

            foreach (var word in wordBank)
            {
                if (target.StartsWith(word))
                {
                    if (G(target[word.Length..], wordBank, memo))
                    {
                        memo.TryAdd(target, true);
                        return true;  
                    }
                }
            }

            memo.TryAdd(target, false);
            return false;
        }
    }
}