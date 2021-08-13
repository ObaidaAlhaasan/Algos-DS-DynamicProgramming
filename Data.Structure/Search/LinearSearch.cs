namespace Data.Structure.Search
{
    public static class LinearSearch
    {
        public static int Find(int[] arr, int item)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] == item)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}