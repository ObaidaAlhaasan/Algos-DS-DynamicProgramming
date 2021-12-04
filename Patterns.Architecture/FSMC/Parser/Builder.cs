using Patterns.Architecture.Tests.FSMC.Parser;

namespace Patterns.Architecture.FSMC.Parser
{
    // builder pattern
    public interface IBuilder
    {
        void NewHeaderWithName();
        void AddHeaderWithValue();
        void SetStateName();
        void Done();
        void SetSuperStateName();
        void SetEvent();
        void SetNullEvent();
        void SetEntryAction();
        void SetExitAction();
        void SetStateBase();
        void SetNextState();
        void SetNullNextState();
        void TransitionWithAction();
        void TransitionNullAction();
        void TransitionWithActions();
        void HeaderError(ParserState state, ParserEvent @event, int line, int pos);
        void StateSpecError(ParserState state, ParserEvent @event, int line, int pos);
        void TransitionError(ParserState state, ParserEvent @event, int line, int pos);
        void TransitionGroupError(ParserState state, ParserEvent @event, int line, int pos);
        void EndError(ParserState state, ParserEvent @event, int line, int pos);
        void SyntaxError(ParserState state, ParserEvent @event, int line, int pos);
        void SyntaxError(int line, int pos);
        void SetName(string name);
        void AddAction();
        void TransitionName();
    }
}