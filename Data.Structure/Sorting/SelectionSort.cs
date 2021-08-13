namespace Data.Structure.Sorting
{
    public class SelectionSort
    {
        public void Sort(int[] arr)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                var smallestIndex = Utils.FindMinIndex(arr, i);
                Utils.Swap(arr, i, smallestIndex);
            }
        }
    }
}