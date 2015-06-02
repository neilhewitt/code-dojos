using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public interface IGameAdapter
    {
        void PrintMyGrid();
        void PrintOpponentGrid();
    }

    public class GameConsoleAdapter : IGameAdapter
    {
        private Game _game;
        private Action<string> _stdout;
        private Func<string> _stdin;
        private IGridAdapter _adapter;

        public void PrintMyGrid()
        {
            _stdout("Player Grid\n-----------\n\n");
            _stdout(_adapter.Render(_game.MyGrid, true, true));
        }

        public void PrintOpponentGrid()
        {
            _stdout("Opponent Grid\n-------------\n\n");
            _stdout(_adapter.Render(_game.OpponentGrid, true, true));
        }

        public GameConsoleAdapter(Game game, Action<string> stdout, Func<string> stdin, IGridAdapter adapter)
        {
            _game = game;
            _stdout = stdout;
            _stdin = stdin;
            _adapter = adapter;
        }
    }
}
