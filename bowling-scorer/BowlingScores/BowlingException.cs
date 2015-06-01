using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenPin.BowlingScores
{
    public class BowlingException : Exception
    {
        public BowlingException() : base()
        {
        }

        public BowlingException(string message) : base(message)
        {
        }

        public BowlingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class InvalidPlayerException : BowlingException
    {
        public InvalidPlayerException() : base()
        {
        }

        public InvalidPlayerException(string message) : base(message)
        {
        }

        public InvalidPlayerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class TooManyPlayersException : BowlingException
    {
        public TooManyPlayersException() : base()
        {
        }

        public TooManyPlayersException(string message) : base(message)
        {
        }

        public TooManyPlayersException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
