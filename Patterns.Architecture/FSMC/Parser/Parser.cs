using Patterns.Architecture.Tests.FSMC.Parser;

namespace Patterns.Architecture.FSMC.Parser
{
    public class Parser : ITokenCollector
    {
        private ParserState State = ParserState.HEADER;
        private IBuilder _builder;

        private Transition[] Transitions = new[]
        {
            new Transition(ParserState.HEADER, ParserEvent.Name, ParserState.HEADERColon, b => b.NewHeaderWithName()),
            new Transition(ParserState.HEADER, ParserEvent.OpenBrace, ParserState.StateSpec, null),
            new Transition(ParserState.HEADERColon, ParserEvent.Colon, ParserState.HEADERValue, null),
            new Transition(ParserState.HEADERValue, ParserEvent.Name, ParserState.HEADER, b => b.AddHeaderWithValue()),
            new Transition(ParserState.StateSpec, ParserEvent.OpenParen, ParserState.SuperStateName, null),
            new Transition(ParserState.StateSpec, ParserEvent.Name, ParserState.StateModifier, b => b.SetStateName()),
            new Transition(ParserState.StateSpec, ParserEvent.CloseBrace, ParserState.End, b => b.Done()),

            new Transition(ParserState.SuperStateName, ParserEvent.Name, ParserState.SuperStateClose, b => b.SetSuperStateName()),
            new Transition(ParserState.SuperStateClose, ParserEvent.CloseParen, ParserState.StateModifier, null),

            new Transition(ParserState.StateModifier, ParserEvent.OpenAngle, ParserState.EntryAction, null),
            new Transition(ParserState.StateModifier, ParserEvent.CloseAngle, ParserState.ExitAction, null),

            new Transition(ParserState.StateModifier, ParserEvent.Colon, ParserState.StateBase, null),
            new Transition(ParserState.StateModifier, ParserEvent.Name, ParserState.SingleEvent, t => t.SetEvent()),
            new Transition(ParserState.StateModifier, ParserEvent.Dash, ParserState.SingleEvent, t => t.SetNullEvent()),
            new Transition(ParserState.StateModifier, ParserEvent.OpenBrace, ParserState.SubTransitionGroup, null),

            new Transition(ParserState.EntryAction, ParserEvent.Name, ParserState.StateModifier, t => t.SetEntryAction()),
            new Transition(ParserState.ExitAction, ParserEvent.Name, ParserState.StateModifier, t => t.SetExitAction()),
            new Transition(ParserState.StateBase, ParserEvent.Name, ParserState.StateModifier, t => t.SetStateBase()),

            new Transition(ParserState.SingleEvent, ParserEvent.Name, ParserState.SingleNextState, t => t.SetNextState()),
            new Transition(ParserState.SingleEvent, ParserEvent.Dash, ParserState.SingleNextState, t => t.SetNullNextState()),


            new Transition(ParserState.GroupNextState, ParserEvent.OpenBrace, ParserState.GroupActionGroup, null),
            new Transition(ParserState.GroupActionGroup, ParserEvent.Name, ParserState.GroupActionGroupName, t => t.AddAction()),
            new Transition(ParserState.GroupActionGroup, ParserEvent.CloseBrace, ParserState.SubTransitionGroup, t => t.TransitionName()),
            new Transition(ParserState.GroupActionGroupName, ParserEvent.Name, ParserState.GroupActionGroupName, t => t.AddAction()),
            new Transition(ParserState.GroupActionGroupName, ParserEvent.CloseBrace, ParserState.SubTransitionGroup, t => t.TransitionName()),


            new Transition(ParserState.End, ParserEvent.EOF, ParserState.End, null),
        };


        public Parser(IBuilder builder)
        {
            _builder = builder;
        }

        public void OpenBrace(int line, int pos)
        {
            HandleEvent(ParserEvent.OpenBrace, line, pos);
        }


        public void CloseBrace(int line, int pos)
        {
            HandleEvent(ParserEvent.CloseBrace, line, pos);
        }

        public void OpenParen(int line, int pos)
        {
            HandleEvent(ParserEvent.OpenParen, line, pos);
        }

        public void ClosedParen(int line, int pos)
        {
            HandleEvent(ParserEvent.CloseParen, line, pos);
        }

        public void OpenAngle(int line, int pos)
        {
            HandleEvent(ParserEvent.OpenAngle, line, pos);
        }

        public void CloseAngle(int line, int pos)
        {
            HandleEvent(ParserEvent.CloseAngle, line, pos);
        }

        public void Dash(int line, int pos)
        {
            HandleEvent(ParserEvent.Dash, line, pos);
        }

        public void Colon(int line, int pos)
        {
            HandleEvent(ParserEvent.Colon, line, pos);
        }

        public void Name(string str, int line, int pos)
        {
            HandleEvent(ParserEvent.Name, line, pos);
        }

        public void Error(int line, int pos)
        {
        }


        private void HandleEvent(ParserEvent parserEvent, int line, int pos)
        {
            foreach (var transition in Transitions)
            {
                if (transition.CurrentState == State && transition.Event == parserEvent)
                {
                    State = transition.NewState;
                    if (transition.Action != null)
                    {
                        transition.Action(_builder);
                    }

                    return;
                }
            }

            HandleEventError(parserEvent, line, pos);
        }

        private void HandleEventError(ParserEvent parserEvent, int line, int pos)
        {
            switch (parserEvent)
            {
                case ParserEvent.OpenBrace:
                    break;
                case ParserEvent.CloseBrace:
                    break;
                case ParserEvent.OpenParen:
                    break;
                case ParserEvent.CloseParen:
                    break;
                case ParserEvent.OpenAngle:
                    break;
                case ParserEvent.CloseAngle:
                    break;
                case ParserEvent.Dash:
                    break;
                case ParserEvent.Colon:
                    break;
                case ParserEvent.Name:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(parserEvent), parserEvent, null);
            }
        }
    }
}