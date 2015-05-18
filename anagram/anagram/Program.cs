using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace anagram
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>(File.ReadAllLines("words.txt"));
            while (true)
            {
                Console.Write("\nEnter word: ");
                string word = Console.ReadLine();
                if (!words.Contains(word.ToLower()))
                {
                    Console.WriteLine("Not a dictionary word!\n\n");
                }
                else
                {
                    Console.WriteLine("\nPermutations\n------------\n");
                    foreach (string permutation in Permute(word))
                        if (words.Contains(permutation))
                            Console.WriteLine(permutation);
                }
                Console.WriteLine("\nThat is all. Press any key to try again.");
                Console.ReadLine();
            }
        }

        public static IEnumerable<string> Permute(string word)
        {
            if (word.Length > 1)
            {

                char character = word[0];
                foreach (string subPermute in Permute(word.Substring(1)))
                {

                    for (int index = 0; index <= subPermute.Length; index++)
                    {
                        string pre = subPermute.Substring(0, index);
                        string post = subPermute.Substring(index);

                        if (post.Contains(character))
                            continue;

                        yield return pre + character + post;
                    }

                }
            }
            else
            {
                yield return word;
            }
        }
    }  
}
