using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TenPin.BowlingScores;

namespace BowlingScoresTests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void CanAddSingleFrame()
        {
            Game game = new Game();
            Assert.That(game.CurrentFrame, Is.Null);
            game.AddFrame("-5");
            Assert.That(game.CurrentFrame, Is.Not.Null);
        }

        [Test]
        public void CanAddTwoFramesPreviousIsNotNull()
        {
            Game game = new Game();
            game.AddFrame("-5");
            game.AddFrame("7/");
            Assert.That(game.CurrentFrame, Is.Not.Null);
            Assert.That(game.CurrentFrame.PreviousFrame, Is.Not.Null);
        }

        [Test]
        public void CanAddTwoFramesPreviousNextIsSecondFrame()
        {
            Game game = new Game();
            game.AddFrame("-5");
            game.AddFrame("7/");
            Assert.That(game.CurrentFrame, Is.Not.Null);
            Assert.That(game.CurrentFrame.PreviousFrame.NextFrame == game.CurrentFrame);
        }

        [Test]
        public void CanAddTwoFramesFrameScoresAreCorrect()
        {
            Game game = new Game();
            game.AddFrame("-5");
            Assert.That(game.CurrentFrame.FirstBallScore == 0 && game.CurrentFrame.SecondBallScore == 5);
            game.AddFrame("7/");
            Assert.That(game.CurrentFrame.FirstBallScore == 7 && game.CurrentFrame.SecondBallScore == 3 && game.CurrentFrame.UnmodifiedTotal == 10);
        }
        [Test]
        public void CanAddFramesCheckFramesScoreCorrectly()
        {
            Game game = new Game();
            game.AddFrame("-5");
            game.AddFrame("7/");
            game.AddFrame("X");
            game.AddFrame("9/");
            IEnumerable<int> totals = game.GetProgressiveScores();
            Assert.That(totals.First() == 5 && totals.Skip(1).First() == 20 && totals.Skip(2).First() == 19 && totals.Count() == 3);
        }

        [Test]
        public void CanAddFramesCheckScoresProgressCorrectly()
        {
            Game game = new Game();
            game.AddFrame("-5");
            game.AddFrame("7/");
            game.AddFrame("X");
            game.AddFrame("9/");
            IEnumerable<int> totals = game.GetProgressiveTotals();
            Assert.That(totals.First() == 5 && totals.Skip(1).First() == 25 && totals.Skip(2).First() == 44 && totals.Count() == 3);
        }

        [Test]
        public void PerfectGameShouldScore300()
        {
            Game game = new Game();
            game.AddFrame("X");
            game.AddFrame("X");
            game.AddFrame("X");
            game.AddFrame("X");
            game.AddFrame("X");
            game.AddFrame("X");
            game.AddFrame("X");
            game.AddFrame("X");
            game.AddFrame("X");
            game.AddFrame("XXX");
            Assert.That(game.Score == 300);
        }

        [Test]
        public void Spare9GameShouldScore190()
        {
            Game game = new Game();
            game.AddFrame("9/");
            game.AddFrame("9/");
            game.AddFrame("9/");
            game.AddFrame("9/");
            game.AddFrame("9/");
            game.AddFrame("9/");
            game.AddFrame("9/");
            game.AddFrame("9/");
            game.AddFrame("9/");
            game.AddFrame("9/9");
            Assert.That(game.Score == 190);
        }
    }
}
