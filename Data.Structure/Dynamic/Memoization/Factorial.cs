namespace Data.Structure.Dynamic.Memoization
{
    public static class Factorial
    {
        public static int G(int num)
        {
            if (num <= 2)
            {
                return num;
            }

            return num * G(num - 1);
        }
    }
}