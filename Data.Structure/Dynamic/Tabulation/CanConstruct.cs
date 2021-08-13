using System;
using System.Collections.Generic;

namespace Data.Structure.Dynamic.Tabulation
{
    public class CanConstruct
    {
        public static bool G(string target, List<string> wordsBank)
        {
            var table = new List<bool>();
            table.Capacity = target.Length + 1;

            table.InsertRange(0, new bool[target.Length + 1]);

            table.Insert(0, true);

            for (var i = 0; i <= target.Length; i++)
            {
                if (table[i] == false)
                    continue;

                foreach (var word in wordsBank)
                {
                    var nextInd = i + word.Length;

                    if (nextInd <= target.Length && word == target.Slice(i, nextInd))
                        table[nextInd] = true;
                }
            }

            return table[target.Length];
        }
    }
}