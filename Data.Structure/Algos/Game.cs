namespace Data.Structure.Algos
{
    public class Game
    {
        private readonly int[] rolls = new int[21];
        private int currentRole;

        public void Roll(int pins) => rolls[currentRole++] = pins;

        public int GetScore()
        {
            var score = 0;
            var firstInFrame = 0;
            for (var frame = 0; frame < 10; frame++)
            {
                if (IsStrike(firstInFrame))
                {
                    score += 10 + NextTwoBallsForStrike(firstInFrame);
                    firstInFrame++;
                }
                else if (IsSpare(firstInFrame))
                {
                    score += 10 + NextBallForSpare(firstInFrame);

                    firstInFrame += 2;
                }
                else
                {
                    score += TwoBallsInFrame(firstInFrame);

                    firstInFrame += 2;
                }
            }

            return score;
        }

        private bool IsStrike(int firstInFrame)
        {
            return rolls[firstInFrame] == 10;
        }

        private int TwoBallsInFrame(int firstInFrame)
        {
            return rolls[firstInFrame] + rolls[firstInFrame + 1];
        }

        private int NextBallForSpare(int firstInFrame)
        {
            return rolls[firstInFrame + 2];
        }

        private int NextTwoBallsForStrike(int firstInFrame)
        {
            return rolls[firstInFrame + 1] + rolls[firstInFrame + 2];
        }

        private bool IsSpare(int firstInFrame)
        {
            return rolls[firstInFrame] + rolls[firstInFrame + 1] == 10;
        }
    }
}