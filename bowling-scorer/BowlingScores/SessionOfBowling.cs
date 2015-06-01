using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenPin.BowlingScores
{
    public class SessionOfBowling
    {
        private IDictionary<string, Game> _gamesByPlayer;
        private int _frameNumber;
        private const int MAX_PLAYERS = 6;

        public IEnumerable<string> PlayerNames { get { return _gamesByPlayer.Keys; } }
        public int CurrentFrameNumber { get { return _frameNumber; } }

        public void AddPlayer(string playerName)
        {
            if (_gamesByPlayer.Keys.Count() >= MAX_PLAYERS)
                throw new TooManyPlayersException("Maximum number of players has been reached.");

            _gamesByPlayer.Add(playerName, new Game());
        }

        public void RemovePlayer(string playerName)
        {
            if (_gamesByPlayer.ContainsKey(playerName))
            {
                _gamesByPlayer.Remove(playerName);
            }
            else
            {
                throw new InvalidPlayerException("Specified player name is not present in the game. Check spelling and case.");
            }
        }

        public void StartBowling()
        {
            foreach(Game game in _gamesByPlayer.Values)
            {
                game.Start();
            }
        }

        public void EndBowling()
        {
            foreach (Game game in _gamesByPlayer.Values)
            {
                game.End();
            }
        }

        public IEnumerable<int> GetTotalsFor(string playerName)
        {
            Game game = GameForPlayer(playerName);
            return game.GetProgressiveTotals();
        }

        public IEnumerable<string> GetFramesFor(string playerName)
        {
            Game game = GameForPlayer(playerName);
            return game.Frames.Select(frame => frame.ToString());
        }

        public IDictionary<string, IEnumerable<int>> GetAllTotals()
        {
            Dictionary<string, IEnumerable<int>> totals = new Dictionary<string, IEnumerable<int>>();
            foreach (string playerName in _gamesByPlayer.Keys)
            {
                totals.Add(playerName, GetTotalsFor(playerName));
            }
            return totals;
        }

        public IDictionary<string, IEnumerable<string>> GetAllFrames()
        {
            Dictionary<string, IEnumerable<string>> totals = new Dictionary<string, IEnumerable<string>>();
            foreach (string playerName in _gamesByPlayer.Keys)
            {
                totals.Add(playerName, GetFramesFor(playerName));
            }
            return totals;
        }

        public void AddPlayerScore(string playerName, string scoreAsString)
        {
            Game game = GameForPlayer(playerName);
            if (game.CurrentFrameNumber == _frameNumber)
            {
                throw new BowlingException("This player already has a score for this frame. Use ChangePlayerScore to change it.");
            }
            game.AddFrame(scoreAsString);
        }

        public bool CanStartNextFrame()
        {
            foreach (Game game in _gamesByPlayer.Values)
            {
                if (game.CurrentFrameNumber != _frameNumber)
                    return false;
            }

            return true;
        }

        public void StartNextFrame()
        {
            foreach(Game game in _gamesByPlayer.Values)
            {
                if (game.CurrentFrameNumber != _frameNumber)
                    throw new BowlingException("At least one player does not have a score for this frame. Cannot move to next frame until all players have played.");
            }

            _frameNumber++;
        }

        private Game GameForPlayer(string playerName)
        {
            Game game = _gamesByPlayer?[playerName];
            if (game == null)
                throw new InvalidPlayerException("Specified player name is invalid");

            return game;
        }

        public SessionOfBowling()
        {
            _gamesByPlayer = new Dictionary<string, Game>();
            _frameNumber = 1;
        }
    }
}
