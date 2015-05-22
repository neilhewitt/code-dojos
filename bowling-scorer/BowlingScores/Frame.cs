using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenPin.BowlingScores
{
    public abstract class Frame
    {
        protected Frame _next;
        protected Frame _previous;

        public int FirstBallScore { get; protected set; }
        public int? SecondBallScore { get; protected set; }

        public Frame NextFrame { get { return _next; } }
        public Frame PreviousFrame { get { return _previous; } }

        public virtual int UnmodifiedTotal { get { return FirstBallScore + (SecondBallScore.HasValue ? SecondBallScore.Value : 0); } }

        public void LinkNext(Frame nextFrame)
        {
            _next = nextFrame;
        }

        public Tuple<int, int, int> GetUnmodifiedScores()
        {
            return GetScores(this.ToString());
        }

        protected Tuple<int, int, int> GetScores(string frameAsString)
        {
            string firstPart = frameAsString.Substring(0, 1);
            string secondPart = (frameAsString.Length > 1 ? frameAsString.Substring(1, 1) : null);
            string thirdPart = (frameAsString.Length > 2 ? frameAsString.Substring(2, 1) : null);
            int first, second, third;
            first = (firstPart == "X" ? 10 : firstPart == "-" ? 0 : int.Parse(firstPart));
            third = (thirdPart == null ? 0 : thirdPart == "X" ? 10 : thirdPart == "-" ? 0 : int.Parse(thirdPart));
            second = (secondPart == null ? 0 : thirdPart != null && secondPart == "X" ? 10 : secondPart == "/" ? 10 - first : secondPart == "-" ? 0 : int.Parse(secondPart));
            return new Tuple<int, int, int>(first, second, third);
        }

        public Frame(Frame previousFrame, string frameAsString)
        {
            _previous = previousFrame;
            Tuple<int, int, int> scores = GetScores(frameAsString);
            FirstBallScore = scores.Item1;
            if (FirstBallScore != 10 || this is TenthFrame)
            {
                SecondBallScore = scores.Item2;
            }
        }
    }

    public class StandardFrame : Frame
    {
        public bool Spared => UnmodifiedTotal == 10 && FirstBallScore != 10;
        public bool Strike => FirstBallScore == 10;

        public override string ToString()
        {
            return (Strike ? "X" : Spared ? FirstBallScore.ToString() + "/" : FirstBallScore.ToString() + SecondBallScore.ToString());
        }

        public StandardFrame(string frameAsString)
            : base(null, frameAsString)
        {
        }

        public StandardFrame(Frame previousFrame, string frameAsString)
            : base(previousFrame, frameAsString)
        {
        }
    }

    public class TenthFrame : Frame
    {
        public int? ThirdBallScore { get; protected set; }

        public override int UnmodifiedTotal { get { return FirstBallScore + (SecondBallScore.HasValue ? SecondBallScore.Value : 0) + (ThirdBallScore.HasValue ? ThirdBallScore.Value : 0); } }

        public override string ToString()
        {
            string frame = String.Empty;
            frame += (FirstBallScore == 10 ? "X" : FirstBallScore == 0 ? "-" : FirstBallScore.ToString());
            frame += (SecondBallScore == 10 ? "X" : SecondBallScore == 0 ? "-" : SecondBallScore + FirstBallScore == 10 ? "/" : SecondBallScore.ToString());
            frame += (ThirdBallScore == 10 ? "X" : ThirdBallScore == 0 ? "-" : ThirdBallScore.ToString());
            return frame;
        }

        public TenthFrame(Frame previousFrame, string frameAsString)
            : base(previousFrame, frameAsString)
        {
            if (FirstBallScore + SecondBallScore >= 10)
            {
                ThirdBallScore = GetScores(frameAsString).Item3;
            }
        }
    }
}
