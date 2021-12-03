namespace Patterns.Architecture.Turnstiles
{
    public class TurnstileFsm
    {
        public TurnstileFsmState ActiveState { get; private set; }
        private Turnstile Turnstile { get; set; }

        public TurnstileFsm(Turnstile turnstile)
        {
            Turnstile = turnstile;
            ActiveState = new LockedTurnstileFsmState(turnstile);
        }

        public void Coin()
        {
            ActiveState.Coin(this);
        }

        public void Pass()
        {
            ActiveState.Pass(this);
        }

        public void SetState(TurnstileFsmState newState)
        {
            ActiveState = newState;
        }
    }
}