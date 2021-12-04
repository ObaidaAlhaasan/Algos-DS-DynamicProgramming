namespace Patterns.Architecture.Tests.FSMC.Parser
{
    public enum ParserEvent
    {
        OpenBrace,
        CloseBrace,
        OpenParen,
        CloseParen,
        OpenAngle,
        CloseAngle,
        Dash,
        Colon,
        Name,
        EOF
    }
}