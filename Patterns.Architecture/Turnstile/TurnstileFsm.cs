using System.Data;
using System.Diagnostics.Contracts;

namespace Patterns.Architecture.Turnstile
{
    public class TurnstileFsm
    {
        public FSMState State { get; private set; }
        private Turnstile Turnstile { get; set; }

        public TurnstileFsm(Turnstile turnstile)
        {
            State = FSMState.Locked;
            Turnstile = turnstile;
        }

        public string HandleEvent(FsmEvent fsmEvent)
        {
            switch (State)
            {
                case FSMState.Locked:
                    switch (fsmEvent)
                    {
                        // Coin even when locked
                        case CoinEvent coinEvent:
                            State = FSMState.Unlocked;
                            Turnstile.UnlockAction();
                            return string.Empty;

                        // Pass event when locked
                        case PassEvent passEvent:
                            return Turnstile.Alarm;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(fsmEvent));
                    }
                case FSMState.Unlocked:
                    switch (fsmEvent)
                    {
                        // passed coin when already unlocked
                        case CoinEvent coinEvent:
                            return Turnstile.ThankYou;

                        // passed turnstile when locked
                        case PassEvent passEvent:
                            State = FSMState.Locked;
                            Turnstile.LockAction();
                            return string.Empty;

                        default:
                            throw new ArgumentOutOfRangeException(nameof(fsmEvent));
                    }

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}