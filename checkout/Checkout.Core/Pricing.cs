using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Core
{
    public class Pricing
    {
        private IDictionary<string, SKU> _skus;

        public IEnumerable<SKU> AllSKUs { get { return _skus.Values; } }

        public SKU For(string sku)
        {
            if (_skus.ContainsKey(sku))
                return _skus[sku];

            throw new ArgumentException("Specified SKU does not exist.");
        }

        public void Add(string name, decimal unitPrice, int multiAmount, decimal multiPrice)
        {
            if (!_skus.ContainsKey(name))
            {
                SKU sku = new SKU(name)
                {
                    UnitPrice = unitPrice
                };

                sku.MultipriceRules.Add(new PricingRule(multiAmount, multiPrice, unitPrice));

                _skus.Add(name, sku);
            }
        }

        public Pricing()
        {
            _skus = new Dictionary<string, SKU>();
        }
    }
}
