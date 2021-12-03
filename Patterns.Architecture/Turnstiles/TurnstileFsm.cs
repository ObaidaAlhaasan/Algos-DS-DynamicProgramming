namespace Patterns.Architecture.Turnstiles
{
    public class TurnstileFsm
    {
        public ITurnstileFsmState ActiveState { get; private set; }
        private Turnstile Turnstile { get; set; }

        public TurnstileFsm(Turnstile turnstile)
        {
            Turnstile = turnstile;
        }

        // Events Functions
        public void Coin()
        {
            ActiveState.Coin(this);
        }

        public void Pass()
        {
            ActiveState.Pass(this);
        }

        public void SetState(ITurnstileFsmState newState) => ActiveState = newState;

        // Actions Functions

        public virtual void Alarm()
        {
            Turnstile.Alarm();
        }

        public virtual void Lock()
        {
            Turnstile.LockAction();
        }

        public virtual void Unlock()
        {
            Turnstile.UnlockAction();
        }

        public virtual void ThankYou()
        {
            Turnstile.ThankYou();
        }
    }
}