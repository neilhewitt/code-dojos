using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenPin.BowlingScores
{
    public class Game
    {
        private Frame _currentFrame = null;
        private int _frameIndex = 0;

        public Frame CurrentFrame { get { return _currentFrame; } }
        public int CurrentFrameNumber { get; private set; }
        public IEnumerable<Frame> Frames { get { return Enumerate(_currentFrame); } }
        public int Score { get { return GetProgressiveTotals().Last(); } }

        public void AddFrame(string frameAsString)
        {
            Frame frame;
            if (Frames.Count() < 9)
            {
                frame = new StandardFrame(_currentFrame, frameAsString);
                if (_currentFrame != null)
                {
                    _currentFrame.LinkNext(frame);
                }
                _currentFrame = frame;
            }
            else
            {
                frame = new TenthFrame(_currentFrame, frameAsString);
                _currentFrame.LinkNext(frame);
                _currentFrame = frame;
            }
        }

        public IEnumerable<int> GetProgressiveTotals()
        {
            int total = 0;
            List<int> totals = new List<int>();
            IEnumerable<int> scores = GetProgressiveScores();
            foreach (int score in scores)
            {
                total += score;
                totals.Add(total);
            }
            return totals;
        }

        public IEnumerable<int> GetProgressiveScores()
        {
            List<int> scores = new List<int>();
            foreach(Frame frame in Frames)
            {
                Tuple<int, int, int> currentScores = frame.GetUnmodifiedScores();
                if (frame is StandardFrame)
                {
                    StandardFrame standardFrame = frame as StandardFrame;
                    if (standardFrame.Strike)
                    {
                        if (standardFrame.NextFrame != null && standardFrame.NextFrame is StandardFrame)
                        {
                            // 8th frame or earlier
                            StandardFrame nextFrame = standardFrame.NextFrame as StandardFrame;
                            if (nextFrame.Strike)
                            {
                                // need to roll to next frame for second ball score
                                if (nextFrame.NextFrame != null)
                                {
                                    scores.Add(currentScores.Item1 + nextFrame.GetUnmodifiedScores().Item1 + nextFrame.NextFrame.GetUnmodifiedScores().Item1);
                                }
                            }
                            else
                            {
                                scores.Add(currentScores.Item1 + currentScores.Item2 + nextFrame.GetUnmodifiedScores().Item1);
                            }
                        }
                        else if (standardFrame.NextFrame != null && standardFrame.NextFrame is TenthFrame)
                        {
                            // we're on the ninth
                            scores.Add(currentScores.Item1 + standardFrame.NextFrame.GetUnmodifiedScores().Item1 + standardFrame.NextFrame.GetUnmodifiedScores().Item2);
                        }

                    }
                    else if (standardFrame.Spared)
                    {
                        if (standardFrame.NextFrame != null)
                        {
                            scores.Add(currentScores.Item1 + currentScores.Item2 + standardFrame.NextFrame.GetUnmodifiedScores().Item1);
                        }
                    }
                    else
                    {
                        scores.Add(currentScores.Item1 + currentScores.Item2); // simple total
                    }
                }
                else if (frame is TenthFrame)
                {
                    scores.Add(currentScores.Item1 + currentScores.Item2 + currentScores.Item3);
                }
            }

            return scores;
        }

        private Frame FindFirst(Frame current)
        {
            while (current.PreviousFrame != null)
                current = current.PreviousFrame;
            return current;
        }

        private IEnumerable<Frame> Enumerate(Frame current)
        {
            List<Frame> frames = new List<Frame>();
            if (current == null) return frames;

            current = FindFirst(_currentFrame);
            do
            {
                frames.Add(current);
                current = current.NextFrame;
            }
            while (current != null);

            return frames;
        }

        public Game()
        {
        }
    }
}
