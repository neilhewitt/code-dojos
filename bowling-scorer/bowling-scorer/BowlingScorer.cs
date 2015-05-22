using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenPin
{
    public class BowlingScorer
    {
        private Dictionary<int, int[]> _frames;

        public int CurrentFrame { get; private set; }
        public int Score { get; }



        public void AddFrame(string frameAsString)
        {
            if (frameAsString.Length < 2 && frameAsString.Length > 3)
                throw new ArgumentException("Invalid frame format, should be {xx}.");

            _frames.Add(++CurrentFrame, new int[frameAsString.Length]);
            int ball;
            if (int.TryParse(frameAsString.Substring(0,1), out ball))
            {
                _frames[CurrentFrame][0] = ball;
            }
            else
            {
                string part = frameAsString.Substring(0, 1);
                ball = (part == "-" ? 0 : part == "X" ? 10 : 0);
            }
            if (frameAsString.Length > 1 && int.TryParse(frameAsString.Substring(1, 1), out ball))
            {
                _frames[CurrentFrame][1] = ball;
            }
            else
            {
                string part = frameAsString.Substring(1, 1);
                ball = (part == "-" ? 0 : part == "/" ? (10 - _frames[CurrentFrame][0]) : 0);
            }
            if (frameAsString.Length == 3 && (int.TryParse(frameAsString.Substring(2, 1), out ball)))
            {
                _frames[CurrentFrame][2] = ball;
            }
            else
            {
                string part = frameAsString.Substring(2, 1);
                ball = (part == "-" ? 0 : part == "X" ? 10 : part == "/" ? (10 - _frames[CurrentFrame][0]) : 0);
            }
        } 

        private void CalculateScore()
        {
            int score = 0;
            for(int i = 0; i < 10; i++)
            {
                bool isStrike;
                int total = TotalForFrame(i, out isStrike);
                score += total;
                if (!isStrike && total == 10)
                {
                    // spare
                    total += TotalForFrame(i + 1, out isStrike);

                    

                }

                
                
            }
        }

        private int TotalForFrame(int frameIndex, out bool isStrike)
        {
            if (!_frames.ContainsKey(frameIndex))
            {
                isStrike = false;
                return 0;
            }

            int[] balls = _frames[frameIndex];
            int total = 0;
            if (balls.Length == 3)
            {
                total = balls[0] + (balls.Length == 2 ? balls[1] : balls.Length == 3 ? balls[1] + balls[2] : 0);
                isStrike = false;
                return total;
            }
            else
            {
                total = balls[0] + (balls.Length == 2 ? balls[1] : 0);
                isStrike = (balls[0] == 10);
                return total;
            }
        }

        public BowlingScorer()
        {
            _frames = new Dictionary<int, int[]>
        }
    }
}
