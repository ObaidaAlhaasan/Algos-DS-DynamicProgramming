namespace Patterns.Architecture.Turnstiles
{
    public class UnlockedTurnstileFsmState : TurnstileFsmState
    {
        public UnlockedTurnstileFsmState(Turnstile turnstile) : base(turnstile)
        {
        }

        public override void Coin(TurnstileFsm turnstileFsm)
        {
            Turnstile.ThankYou();
        }

        public override void Pass(TurnstileFsm turnstileFsm)
        {
            Turnstile.LockAction();
            turnstileFsm.SetState(new LockedTurnstileFsmState(Turnstile));
        }
    }
}