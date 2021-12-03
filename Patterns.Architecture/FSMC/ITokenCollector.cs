namespace Patterns.Architecture.FSMC
{
    public interface ITokenCollector
    {
        // each one represent one of the toke in our syntax
        // Collector have a function for each token
        // Character => Function Calls

        void OpenBrace(int line, int pos);
        void CloseBrace(int line, int pos);
        void OpenParen(int line, int pos);
        void ClosedParen(int line, int pos);
        void OpenAngle(int line, int pos);
        void CloseAngle(int line, int pos);
        void Dash(int line, int pos);
        void Colon(int line, int pos);
        void Name(string str, int line, int pos);
        void Error(int line, int pos);
    }
}