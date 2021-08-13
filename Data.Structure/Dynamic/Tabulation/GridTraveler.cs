namespace Data.Structure.Dynamic.Tabulation
{
    public static class GridTraveler
    {
        public static long G(int row, int col)
        {
            var table = new long[row + 1, col + 1];

            table[1, 1] = 1;

            for (var i = 0; i <= row; i++)
            {
                for (var j = 0; j <= col; j++)
                {
                    var current = table[i, j];

                    if (i + 1 <= row)
                        table[i + 1, j] += current;

                    if (j + 1 <= col)
                        table[i, j + 1] += current;
                }
            }

            return table[row, col];
        }
    }
}