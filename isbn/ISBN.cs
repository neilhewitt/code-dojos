using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isbn
{
    public static class ISBN
    {
        public static bool IsValid(string isbn)
        {
            // check dashes
            if (isbn[1] == '-' && isbn[6] == '-' && isbn[11] == '-')
            {
                long sum = 0;
                int multiplier = 10;
                foreach(char c in isbn)
                {
                    if (char.IsNumber(c) || (c == 'X' && multiplier == 1))
                    {
                        sum = sum + (multiplier-- * (c == 'X' ? 10 : c-48));
                    }
                }
                if (sum % 11 == 0) return true;
            }

            return false;
        }

        public static string New(out int loopCount)
        {
            Random random = new Random();
            int maxLoops = int.MaxValue;
            while (true)
            {
                if (maxLoops-- == 0)
                    throw new InvalidOperationException("Well, I just give up...");

                // yay for brute force
                int[] digits = new int[10];
                for (int i = 0; i < 9; i++)
                {
                    digits[i] = random.Next(0, 9);
                }
                digits[9] = random.Next(0, 10);

                string isbn = digits[0] + "-" + Concat(digits.Skip(1).Take(4)) + "-" + Concat(digits.Skip(5).Take(4)) + "-"
                    + (digits.Last() == 10 ? "X" : digits.Last().ToString());
                if (IsValid(isbn))
                {
                    loopCount = int.MaxValue - maxLoops;
                    return isbn;
                }
            }
        }

        private static string Concat(IEnumerable<int> numbers)
        {
            string output = "";
            foreach (int number in numbers)
                output += number.ToString();
            return output;
        }
    }
}
