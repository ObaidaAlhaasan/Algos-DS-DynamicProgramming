using System.Threading.Tasks;
using Patterns.Architecture.Turnstiles;
using Xunit;

namespace Patterns.Architecture.Tests.TurnstileTests
{
    public class TurnstileFsmTests
    {
        private TurnstileFsm _fsm;

        public TurnstileFsmTests()
        {
            _fsm = new TurnstileFsm(new Turnstile());
        }

        [Fact]
        public async Task initially_Locked()
        {
            Assert.True(_fsm.ActiveState is LockedTurnstileFsmState);
        }

        [Fact]
        public async Task AddingCoin_WhenLocked_ShouldBeUnlocked()
        {
            _fsm.Coin();
            Assert.True(_fsm.ActiveState is UnlockedTurnstileFsmState);
        }

        [Fact]
        public async Task PassingTurnstile_WhenLocked_ShouldBe_LockedAndSendAlarm()
        {
            _fsm.Pass();
            // Assert.Equal("Alarm, someone passed turnstile without passing a coin", alarm);
            Assert.True(_fsm.ActiveState is LockedTurnstileFsmState);
        }

        [Fact]
        public async Task PassingCoin_WhenUnlocked_ShouldBe_UnlockedAndSendThankYou()
        {
            _fsm.Coin();

            // Assert.Empty(thankYouFirstTime);
            // Assert.Equal("Thank you, you already inserted a coin", thankYouSecondTime);
        }

        [Fact]
        public async Task PassingEvent_WhenUnlocked_ShouldBackToLocked()
        {
            _fsm = new TurnstileFsm(new Turnstile());
            Assert.True(_fsm.ActiveState is LockedTurnstileFsmState);

            _fsm.Coin();
            Assert.True(_fsm.ActiveState is UnlockedTurnstileFsmState);

            _fsm.Pass();
            Assert.True(_fsm.ActiveState is LockedTurnstileFsmState);

            // Assert.Empty(msg);
            // Assert.Empty(passMsg);
        }
    }
}