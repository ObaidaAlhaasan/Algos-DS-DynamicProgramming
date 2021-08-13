using System.Collections.Generic;
using System.Linq;

namespace Data.Structure.Dynamic.Tabulation
{
    public class AllConstruct
    {
        public static List<List<string>> G(string target, List<string> wordsBank)
        {
            var table = new List<List<List<string>>>
            {
                Capacity = target.Length + 1
            };

            for (var i = 0; i <= target.Length; i++)
                table.Insert(i, new List<List<string>>());

            table[0] = new List<List<string>> { new() };

            for (var i = 0; i <= target.Length; i++)
            {
                foreach (var word in wordsBank)
                {
                    var nextIndex = i + word.Length;
                    if (nextIndex <= target.Length && word == target.Slice(i, nextIndex))
                    {

                        var newCombination = table[i].Select(sub =>
                        {
                            var s = new List<string>();
                            s.AddRange(sub);
                            s.Add(word);
                            return s;
                        }).ToList();

                        table[nextIndex].AddRange(newCombination);
                    }
                }
            }

            return table[target.Length];
        }
    }
}