using Data.Structure.Algos;
using Xunit;

namespace Data.Structure.Tests.Algos
{
    public class BowlingTests
    {
        private readonly Game game;

        public BowlingTests()
        {
            game = new Game();
        }

        [Fact]
        public void GutterGame()
        {
            RollMany(20, 0);
            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void AllOnes()
        {
            RollMany(20, 1);
            Assert.Equal(20, game.GetScore());
        }

        [Fact]
        public void OneSpare()
        {
            RollSpare();
            game.Roll(3);

            RollMany(17, 0);

            Assert.Equal(16, game.GetScore());
        }

        [Fact]
        public void OneStrike()
        {
            RollStrike();
            game.Roll(3);
            game.Roll(4);

            RollMany(16, 0);

            Assert.Equal(24, game.GetScore());
        }

        [Fact]
        public void PerfectGame()
        {
            RollMany(12, 10);
            Assert.Equal(300, game.GetScore());
        }


        private void RollStrike() => game.Roll(10);


        private void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }


        private void RollMany(int n, int pins)
        {
            for (var i = 0; i < n; i++)
                game.Roll(pins);
        }
    }
}