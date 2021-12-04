using Patterns.Architecture.Turnstiles;

namespace Patterns.Architecture.TrunstileTable
{
    public class Transition
    {
        public State CurrentState { get; private set; }
        public FsmEvent Event { get; private set; }
        public State NewState { get; private set; }
        public Action<Turnstiles.Turnstile> Action { get; private set; }

        public Transition[] Transitions =
        {
            new(State.Locked, new CoinEvent(), State.Unlocked, t => t.UnlockAction()),
            new(State.Locked, new PassEvent(), State.Locked, t => t.Alarm()),
            new(State.Unlocked, new CoinEvent(), State.Unlocked, t => t.ThankYou()),
            new(State.Unlocked, new PassEvent(), State.Locked, t => t.LockAction()),
        };

        public Transition(State currentState, FsmEvent @event, State newState, Action<Turnstiles.Turnstile> action)
        {
            CurrentState = currentState;
            Event = @event;
            NewState = newState;
            Action = action;
        }

        public void HandleEvent(FsmEvent fsmEvent, State state, Turnstiles.Turnstile turnstile)
        {
            foreach (var t in Transitions)
            {
                if (t.CurrentState == state && t.Event == fsmEvent)
                {
                    CurrentState = t.NewState;
                    t.Action(turnstile);
                    break;
                }
            }
        }
    }

    public enum State
    {
        Locked,
        Unlocked
    }
}