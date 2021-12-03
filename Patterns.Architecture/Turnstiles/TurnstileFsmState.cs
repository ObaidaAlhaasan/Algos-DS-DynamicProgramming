namespace Patterns.Architecture.Turnstiles
{
    public interface ITurnstileFsmState
    {
        public void Coin(TurnstileFsm turnstileFsm);
        public void Pass(TurnstileFsm turnstileFsm);
    }
}