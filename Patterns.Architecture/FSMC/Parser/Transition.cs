using Patterns.Architecture.Tests.FSMC.Parser;

namespace Patterns.Architecture.FSMC.Parser
{
    public class Transition
    {
        public ParserState CurrentState { get; private set; }
        public ParserEvent Event { get; private set; }
        public ParserState NewState { get; private set; }
        public Action<IBuilder> Action { get; private set; }

        public Transition(ParserState currentState, ParserEvent @event, ParserState newState, Action<IBuilder> action)
        {
            CurrentState = currentState;
            Event = @event;
            NewState = newState;
            Action = action;
        }
    }
}