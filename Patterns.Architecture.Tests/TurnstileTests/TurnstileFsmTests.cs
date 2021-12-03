using System.Threading.Tasks;
using Patterns.Architecture.Turnstile;
using Xunit;

namespace Patterns.Architecture.Tests.TurnstileTests
{
    public class TurnstileFsmTests
    {
        private TurnstileFsm _fsm;

        public TurnstileFsmTests()
        {
            _fsm = new TurnstileFsm(new Turnstile.Turnstile());
        }

        [Fact]
        public async Task initially_Locked()
        {
            Assert.Equal(_fsm.State, FSMState.Locked);
        }

        [Fact]
        public async Task AddingCoin_WhenLocked_ShouldBeUnlocked()
        {
            _fsm.HandleEvent(new CoinEvent());

            Assert.Equal(_fsm.State, FSMState.Unlocked);
        }

        [Fact]
        public async Task PassingTurnstile_WhenLocked_ShouldBe_LockedAndSendAlarm()
        {
            var alarm = _fsm.HandleEvent(new PassEvent());
            Assert.Equal("Alarm, someone passed turnstile without passing a coin", alarm);
            Assert.Equal(_fsm.State, FSMState.Locked);
        }

        [Fact]
        public async Task PassingCoin_WhenUnlocked_ShouldBe_UnlockedAndSendThankYou()
        {
            var thankYouFirstTime = _fsm.HandleEvent(new CoinEvent());
            var thankYouSecondTime = _fsm.HandleEvent(new CoinEvent());


            Assert.Empty(thankYouFirstTime);
            Assert.Equal("Thank you, you already inserted a coin", thankYouSecondTime);
        }

        [Fact]
        public async Task PassingEvent_WhenUnlocked_ShouldBackToLocked()
        {
            Assert.Equal(_fsm.State, FSMState.Locked);

            var msg = _fsm.HandleEvent(new CoinEvent());
            Assert.Equal(_fsm.State, FSMState.Unlocked);

            var passMsg = _fsm.HandleEvent(new PassEvent());

            Assert.Empty(msg);
            Assert.Empty(passMsg);
            Assert.Equal(_fsm.State, FSMState.Locked);
        }
    }
}