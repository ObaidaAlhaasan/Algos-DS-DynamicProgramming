using System.Collections.Generic;

namespace Patterns.Architecture.FSMC.FSMSyntax
{
    public class FsmSyntax
    {
        public List<Header> Headers { get; private set; }
        public List<Transition> Transitions { get; private set; }
        public List<SyntaxError> SyntaxErrors { get; private set; }
        public bool Done { get; private set; }
    }

    public class Header
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class Transition
    {
        public StateSpec State { get; set; }
        public List<SubTransition> SubTransitions { get; set; }
    }

    public class StateSpec
    {
        public string Name { get; set; }
        public string SuperState { get; set; }
        public string EntryAction { get; set; }
        public string ExitAction { get; set; }
        public bool AbstractState { get; set; }
    }

    public class SubTransition
    {
        public string Event { get; set; }
        public string NextState { get; set; }
        private List<string> Actions = new List<string>();

        public SubTransition(string evt)
        {
            Event = evt;
        }
    }

    public class SyntaxError
    {
    }
}