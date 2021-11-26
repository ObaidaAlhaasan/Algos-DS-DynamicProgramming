using System.Collections.Generic;
using System.Linq;

namespace Data.Structure.Algos
{
    public class NameInverter
    {
        public string Invert(string? text)
        {
            if (text.IsNullOrEmpty())
                return string.Empty;

            return FormatNames(RemoveHonorific(text));
        }

        private string FormatNames(string? name)
        {
            var names = name?.ReplaceMultipleWhiteSpacesWithOne().Split(' ');

            if (IsPostNominal(names))
                return FormatMultiEleName(names);

            return names?.Reverse().Join(", ") ?? string.Empty;
        }

        private string FormatMultiEleName(string[] names)
        {
            var firstName = names.ElementAtOrDefault(0);
            var lastName = names.ElementAtOrDefault(1);
            var postNominal = GetPostNominal(names);
            return $"{lastName}, {firstName} {postNominal}".Trim();
        }

        private string? RemoveHonorific(string? name)
        {
            if (IsHonorific(name))
                name = ReplaceHonorific(name);
            return name;
        }

        private string GetPostNominal(string[] names)
        {
            var nominal = names.Skip(2).ToList();

            return nominal.Aggregate(string.Empty, (current, nm) => current + nm + " ");
        }

        private static bool IsPostNominal(string[] names) => names.Length > 2;

        private static string? ReplaceHonorific(string? name)
        {
            name = name?.Replace("Mr.", "");
            name = name?.Replace("Mrs.", "");
            return name;
        }

        private bool IsHonorific(string name) => name.ContainsIgnoreCase("Mr.") || name.ContainsIgnoreCase("Mrs.");
    }
}