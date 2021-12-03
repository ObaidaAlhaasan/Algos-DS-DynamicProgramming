namespace Patterns.Architecture.Turnstiles
{
    public abstract class TurnstileFsmState
    {
        protected Turnstile Turnstile { get; private set; }

        protected TurnstileFsmState(Turnstile turnstile) => Turnstile = turnstile;

        public abstract void Coin(TurnstileFsm turnstileFsm);
        public abstract void Pass(TurnstileFsm turnstileFsm);
    }
}