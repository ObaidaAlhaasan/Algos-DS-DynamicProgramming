using Patterns.Architecture.FSMC;

namespace Patterns.Architecture.Tests.FSMC.LexerTests
{
    public class LexerTests : ITokenCollector
    {
        private string tokens = "";
        private Lexer _lexer;
        private bool FirstToken = true;

        public LexerTests()
        {
            _lexer = new Lexer(this);
        }

        private void AddToken(string token)
        {
            if (!FirstToken)
            {
                tokens += ",";
            }

            tokens += token;
            FirstToken = false;
        }

        public void AssertLexResult(string input, string expected)
        {
            _lexer.Lex(input);
            Assert.Equal(expected, tokens);
        }

        public void OpenBrace(int line, int pos)
        {
            AddToken("OB");
        }

        public void CloseBrace(int line, int pos)
        {
            AddToken("CB");
        }

        public void OpenParen(int line, int pos)
        {
            AddToken("OP");
        }

        public void ClosedParen(int line, int pos)
        {
            AddToken("CP");
        }

        public void OpenAngle(int line, int pos)
        {
            AddToken("OA");
        }

        public void CloseAngle(int line, int pos)
        {
            AddToken("CA");
        }

        public void Dash(int line, int pos)
        {
            AddToken("D");
        }

        public void Colon(int line, int pos)
        {
            AddToken("C");
        }

        public void Name(string str, int line, int pos)
        {
            AddToken("#" + str + "#");
        }

        public void Error(int line, int pos)
        {
            AddToken("E" + line + "/" + pos);
        }


        #region SingleTokenTests

        [Fact]
        public async Task FindsOpenBrace()
        {
            AssertLexResult("{", "OB");
        }

        [Fact]
        public async Task FindsClosedBrace()
        {
            AssertLexResult("}", "CB");
        }


        [Fact]
        public async Task FindsOpenParan()
        {
            AssertLexResult("(", "OP");
        }

        [Fact]
        public async Task FindsClosedParan()
        {
            AssertLexResult(")", "CP");
        }


        [Fact]
        public async Task FindsOpenAngle()
        {
            AssertLexResult("<", "OA");
        }

        [Fact]
        public async Task FindsClosedAngle()
        {
            AssertLexResult(">", "CA");
        }


        [Fact]
        public async Task FindsDash()
        {
            AssertLexResult("-", "D");
        }

        [Fact]
        public async Task FindsColon()
        {
            AssertLexResult(":", "C");
        }

        [Fact]
        public async Task FindsSimpleName()
        {
            AssertLexResult("name", "#name#");
        }


        [Fact]
        public async Task FindsComplexName()
        {
            AssertLexResult("Room_222", "#Room_222#");
        }


        [Fact]
        public async Task FindsError()
        {
            AssertLexResult(".", "E1/1");
        }


        [Fact]
        public async Task NothingButWhiteSpace()
        {
            AssertLexResult("   ", "");
        }


        [Fact]
        public async Task WhiteSpaceBefore()
        {
            AssertLexResult("  \t\n  -", "D");
        }

        #endregion


        #region MultipleTokenTests

        [Fact]
        public async Task SimpleSequence()
        {
            AssertLexResult("{}", "OB,CB");
        }

        [Fact]
        public async Task ComplexSequence()
        {
            AssertLexResult("FSM:fsm{this}", "#FSM#,C,#fsm#,OB,#this#,CB");
        }

        [Fact]
        public async Task AllTokens()
        {
            AssertLexResult("{}()<>-: name .", "OB,CB,OP,CP,OA,CA,D,C,#name#,E1/15");
        }

        [Fact]
        public async Task MultipleLines()
        {
            AssertLexResult("FSM:fsm.\n{bob-.}", "#FSM#,C,#fsm#,E1/8,OB,#bob#,D,E2/6,CB");
        }

        #endregion
    }
}