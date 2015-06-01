using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenPin.BowlingScores;

namespace TenPin.BowlingScores.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SessionOfBowling session = new SessionOfBowling();
            Console.WriteLine("Neil's Simple Bowling Simulator v1.0\n------------------------------------\n");
            Console.WriteLine("Input player names below (max 6 players, enter empty string to finish).\n");
            int playerCount = 1;
            while (playerCount <= 6)
            {
                Console.Write("Player " + playerCount.ToString() + " name: ");
                string playerName = Console.ReadLine();
                if (playerName == "")
                    break;
                session.AddPlayer(playerName);
                playerCount++;
                if (playerCount == 7)
                    break;
            }
            Console.WriteLine("\n\nOK, we're ready to bowl... press any key to begin.\n\n");

            // begin bowling
            session.StartBowling();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("FRAME " + (i + 1).ToString() + "\n======" + (i > 9 ? "==" : "="));
                foreach (string playerName in session.PlayerNames)
                {
                    Console.Write("Enter score for Player " + playerName + " in format (nn): ");
                    string scoreAsString = Console.ReadLine();
                    session.AddPlayerScore(playerName, scoreAsString);
                }

                Console.WriteLine("\nScores at FRAME " + (i + 1).ToString() + ":\n");
                IDictionary<string, IEnumerable<int>> scores = session.GetAllTotals();
                IDictionary<string, IEnumerable<string>> frames = session.GetAllFrames();
                foreach(string key in scores.Keys)
                {
                    int[] playerScores = scores[key].ToArray();
                    string[] playerFrames = frames[key].ToArray();
                    string scoreLine = "";
                    for (int j = 0; j < playerFrames.Length; j++)
                    {
                        scoreLine += playerFrames[j] + " (" + (playerScores.Length > j ? playerScores[j].ToString() : "N/A") + ") | ";
                    }
                    scoreLine = scoreLine.TrimEnd('|', ' ');
                    Console.WriteLine(key + ": " + scoreLine);
                }

                Console.WriteLine("\nBeginning next frame...\n\n");
            }

            Console.ReadLine();
        }
    }
}
