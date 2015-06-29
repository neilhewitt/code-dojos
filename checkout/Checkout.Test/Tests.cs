using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Checkout.Core;

namespace Checkout.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void CanAddSKUToPricing()
        {
            Pricing pricing = new Pricing();
            pricing.Add("A", 50, 3, 130);
            Assert.That(pricing.For("A"), Is.Not.Null);
            Assert.That(pricing.For("A").UnitPrice == 50);
        }

        [Test]
        public void CalculateSKUToPricing()
        {
            Pricing pricing = new Pricing();
            pricing.Add("A", 50, 3, 130);
            Assert.That(pricing.For("A"), Is.Not.Null);
            Assert.That(pricing.For("A").UnitPrice == 50);

            var checkout = new Checkout.Core.Checkout();

            var basket = new ShoppingBasket();

            var item = pricing.For("A");

            basket.Add(item);

            var total = checkout.Calculate(basket);
        }
    }
}
