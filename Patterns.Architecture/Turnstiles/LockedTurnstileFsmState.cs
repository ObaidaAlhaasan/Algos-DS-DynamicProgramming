namespace Patterns.Architecture.Turnstiles
{
    public class LockedTurnstileFsmState : TurnstileFsmState
    {
        public LockedTurnstileFsmState(Turnstile turnstile) : base(turnstile)
        {
        }

        public override void Coin(TurnstileFsm turnstileFsm)
        {
            Turnstile.UnlockAction();
            turnstileFsm.SetState(new UnlockedTurnstileFsmState(Turnstile));
        }

        public override void Pass(TurnstileFsm turnstileFsm)
        {
            Turnstile.Alarm();
        }
    }
}