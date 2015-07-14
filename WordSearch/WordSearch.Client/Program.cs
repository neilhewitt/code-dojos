using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordSearch.Core;

namespace WordSearch.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = new string[]
            {
                "UEWRTRBHCD",
                "CXGZUWRYER",
                "ROCKSBAUCU",
                "SFKFMTYSGE",
                "YSOOUNMZIM",
                "TCGPRTIDAN",
                "HZGHQGWTUV",
                "HQMNDXZBST",
                "NTCLATNBCE",
                "YBURPZUXMS"
            };

            string[] words = new string[]
            {
                "Ruby", "rocks", "DAN", "matZ"
            };

            WordSearcher searcher = new WordSearcher(lines, words);
            WordSearchResults solution = searcher.Solve();
            foreach(Result item in solution.Items)
            {
                Console.WriteLine("Word: " + item.Word + " was found at [" + item.X.ToString() + "," + item.Y.ToString() + "] in direction " + Enum.GetName(typeof(Grid.Direction), item.Direction));
            }

            Console.ReadLine();
        } 
    }
}
