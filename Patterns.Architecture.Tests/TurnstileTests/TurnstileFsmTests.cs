global using Xunit;
global using System.Threading.Tasks;
using Patterns.Architecture.Turnstiles;

namespace Patterns.Architecture.Tests.TurnstileTests
{
    public class TurnstileFsmTests : TurnstileFsm
    {
        private string Actions;

        public TurnstileFsmTests() : base(new Turnstile())
        {
            SetState(new OneCoinTurnStileStateLocked());
            Actions = "";
        }

        [Fact]
        public async Task NormalOperation()
        {
            Coin();
            AssertActions("U");
            Pass();
            AssertActions("UL");
            // Assert.True(_fsm.ActiveState is OneCoinTurnStileStateLocked);
        }

        [Fact]
        public async Task ForcedEntry()
        {
            Pass();
            AssertActions("A");
        }

        [Fact]
        public async Task DoublePayment()
        {
            Coin();
            Coin();
            AssertActions("UT");
            // Assert.True(_fsm.ActiveState is OneCoinTurnStileStateUnlocked);
        }


        [Fact]
        public async Task ManyCoins()
        {
            for (int i = 0; i < 5; i++)
                Coin();

            AssertActions("UTTTT");
            // Assert.True(_fsm.ActiveState is OneCoinTurnStileStateLocked);
        }


        [Fact]
        public async Task ManyCoinsThenPass()
        {
            for (int i = 0; i < 5; i++)
                Coin();

            Pass();

            AssertActions("UTTTTL");
            // Assert.True(_fsm.ActiveState is OneCoinTurnStileStateLocked);
        }

        [Fact(Skip = "Old implementation")]
        public async Task PassingCoin_WhenUnlocked_ShouldBe_UnlockedAndSendThankYou()
        {
            Coin();

            // Assert.Empty(thankYouFirstTime);
            // Assert.Equal("Thank you, you already inserted a coin", thankYouSecondTime);
        }

        [Fact(Skip = "Old implementation")]
        public async Task PassingEvent_WhenUnlocked_ShouldBackToLocked()
        {
            Assert.True(ActiveState is OneCoinTurnStileStateLocked);

            Coin();
            Assert.True(ActiveState is OneCoinTurnStileStateUnlocked);

            Pass();
            Assert.True(ActiveState is OneCoinTurnStileStateLocked);
            // Assert.Empty(msg);
            // Assert.Empty(passMsg);
        }

        public override void Alarm()
        {
            Actions += "A";
        }

        public override void ThankYou()
        {
            Actions += "T";
        }

        public override void Unlock()
        {
            Actions += "U";
        }

        public override void Lock()
        {
            Actions += "L";
        }

        public void AssertActions(string expected)
        {
            Assert.Equal(expected, Actions);
        }
    }
}