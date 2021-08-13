namespace Data.Structure.Sorting
{
    public class BubbleSort
    {
        public void SortACS(int[] arr)
        {
            // optimization
            // Assumption that we have sorted list and set it to false if we do swap
            // in each iteration we bubble up next largest item so no need to loop over all the array

            var isSorted = true;
            for (var i = 0; i < arr.Length; i++)
            {
                for (var j = 1; j < arr.Length - i; j++)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        Swap(arr, j, j - 1);
                        isSorted = false;
                    }
                }

                if (isSorted)
                    return;
            }
        }

        public void SortDESC(int[] arr)
        {
            var isSorted = true;
            for (var i = 0; i < arr.Length; i++)
            {
                for (var j = 1; j < arr.Length - i; j++)
                {
                    if (arr[j] > arr[j - 1])
                    {
                        Swap(arr, j, j - 1);
                        isSorted = false;
                    }
                }

                if (isSorted)
                    return;
            }
        }

        private void Swap(int[] arr, int f, int s)
        {
            var temp = arr[f];
            arr[f] = arr[s];
            arr[s] = temp;
        }
    }
}