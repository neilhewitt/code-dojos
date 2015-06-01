using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace isbn
{
    [TestFixture]
    public class ISBNTests
    {
        [Test]
        public void ValidISBNIsValid()
        {
            Assert.That(ISBN.IsValid("0-7475-3269-9"));
        }

        [Test]
        public void InvalidISBNIsInvalid()
        {
            Assert.That(!ISBN.IsValid("0-7405-3269-9"));
        }

        [Test]
        public void GeneratedISBNIsValid()
        {
            int loops = 0;
            string isbn = ISBN.New(out loops);
            Assert.That(ISBN.IsValid(isbn));
        }

        [Test]
        public void FiveHundredGeneratedISBNsAreValid()
        {
            int loops = 0;
            for (int i = 0; i < 500; i++)
            {
                string isbn = ISBN.New(out loops);
                Assert.That(ISBN.IsValid(isbn));
            }
        }
    }
}
