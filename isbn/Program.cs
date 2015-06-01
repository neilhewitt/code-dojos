using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isbn
{
    class Program
    {
        static void Main(string[] args)
        {
            string isbn = String.Empty;
            while (true)
            {
                Console.Write("Enter an ISBN number (including dashes): ");
                isbn = Console.ReadLine();
                if (isbn == "") break;

                Console.WriteLine("That ISBN number is " + (ISBN.IsValid(isbn.Trim()) ? "VALID" : "INVALID"));
            }

            while(true)
            {
                Console.Write("Press any key to generate valid ISBNs: ");
                Console.ReadLine();
                int maxLoops = 0;
                for (int i = 0; i < 10000; i++)
                {
                    int loops = 0;
                    isbn = ISBN.New(out loops);
                    if (loops > maxLoops)
                        maxLoops = loops;
                }
                Console.WriteLine("Max loops was: " + maxLoops.ToString());
            }
        }
    }
}