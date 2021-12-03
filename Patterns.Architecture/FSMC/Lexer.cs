using System.Linq;
using System.Text.RegularExpressions;

namespace Patterns.Architecture.FSMC
{
    public class Lexer
    {
        public ITokenCollector Collector { get; private set; }
        public int LineNumber { get; private set; }
        public int Position { get; private set; }

        public Lexer(ITokenCollector collector)
        {
            Collector = collector;
        }

        public void Lex(string s)
        {
            LineNumber = 1;
            var lines = s.Split("\n");

            foreach (var line in lines)
            {
                LexLine(line);
                LineNumber++;
            }
        }

        private void LexLine(string line)
        {
            for (Position = 0; Position < line.Length;)
                LexToken(line);
        }

        private void LexToken(string line)
        {
            if (!FindToken(line))
            {
                Collector.Error(LineNumber, Position + 1);
                Position += 1;
            }
        }

        private bool FindToken(string line) => FindWhiteSpace(line) || FindSingleCharactersToken(line) || FineName(line);

        private static string WhiteSpacePattern = "^\\s+";

        private bool FindWhiteSpace(string line)
        {
            var match = new Regex(WhiteSpacePattern).Match(line.Substring(Position));

            if (match.Success)
            {
                Position += match.Length;
                return true;
            }

            return false;
        }

        private bool FindSingleCharactersToken(string line)
        {
            var c = line.ElementAt(Position).ToString();
            //
            // if (Position + 1 < line.Length)
            //     c = line.Substring(Position, Position + 1);
            // else
            //     c = line.Substring(Position);

            switch (c)
            {
                case "{":
                    Collector.OpenBrace(LineNumber, Position);
                    break;
                case "}":
                    Collector.CloseBrace(LineNumber, Position);
                    break;

                case "(":
                    Collector.OpenParen(LineNumber, Position);
                    break;
                case ")":
                    Collector.ClosedParen(LineNumber, Position);
                    break;

                case "<":
                    Collector.OpenAngle(LineNumber, Position);
                    break;
                case ">":
                    Collector.CloseAngle(LineNumber, Position);
                    break;

                case "-":
                    Collector.Dash(LineNumber, Position);
                    break;
                case ":":
                    Collector.Colon(LineNumber, Position);
                    break;
                default:
                    return false;
            }

            Position++;
            return true;
        }

        private static string NamePattern = "^\\w+";

        private bool FineName(string line)
        {
            var match = new Regex(NamePattern).Match(line.Substring(Position));
            if (match.Success)
            {
                Collector.Name(match.Value, LineNumber, Position);
                Position += match.Length;
                return true;
            }

            return false;
        }
    }
}