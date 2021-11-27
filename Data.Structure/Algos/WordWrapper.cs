namespace Data.Structure.Algos
{
    public class WordWrapper
    {
        public static string Wrap(string text, int width)
        {
            if (text.IsNullOrEmpty())
                return string.Empty;

            if (text.Length <= width)
                return text;

            var breakpoint = text.LastIndexOf(' ', width);
            if (breakpoint == -1)
                breakpoint = width;

            return text[..breakpoint] + "\n" + Wrap(text[breakpoint..].Trim(), width);
        }
    }
}