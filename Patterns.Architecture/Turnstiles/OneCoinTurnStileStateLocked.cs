namespace Patterns.Architecture.Turnstiles
{
    public class OneCoinTurnStileStateLocked : ITurnstileFsmState
    {
        public void Coin(TurnstileFsm fsm)
        {
            fsm.SetState(new OneCoinTurnStileStateUnlocked());
            fsm.Unlock();
        }

        public void Pass(TurnstileFsm fsm) => fsm.Alarm();
    }

    public class OneCoinTurnStileStateUnlocked : ITurnstileFsmState
    {
        public void Coin(TurnstileFsm fsm) => fsm.ThankYou();

        public void Pass(TurnstileFsm fsm)
        {
            fsm.SetState(new OneCoinTurnStileStateLocked());
            fsm.Lock();
        }
    }
}