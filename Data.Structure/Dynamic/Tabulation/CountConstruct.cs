using System.Collections.Generic;

namespace Data.Structure.Dynamic.Tabulation
{
    public class CountConstruct
    {
        public static int G(string target, List<string> wordsBank)
        {
            var table = new List<int?>
            {
                Capacity = target.Length + 1
            };

            for (var i = 0; i <= target.Length; i++)
                table.Insert(i, 0);

            table[0] = 1;

            for (var i = 0; i <= target.Length; i++)
            {
                if (table[i] == 0)
                    continue;

                foreach (var word in wordsBank)
                {
                    var nextInd = i + word.Length;
                    if (nextInd <= target.Length && word == target.Slice(i, nextInd))
                        table[nextInd] += table[i];
                }
            }

            return (int)(table[target.Length] == null ? 0 : table[target.Length]);
        }
    }
}