using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Core
{
    public class PricingRule
    {
        private readonly Func<int, decimal> _rule;

        public PricingRule(int multiOfferAmount, decimal multiPrice, decimal unitPrice)
        {
            _rule = n =>
            {
                return (multiOfferAmount / n) + ((n % multiOfferAmount) * unitPrice);
            };
        }

        public virtual decimal Calculate(int numberOfUnits)
        {
            return _rule(numberOfUnits);
        }
    }
}
