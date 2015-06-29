using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Core
{
    public class Checkout
    {
        public decimal Total { get; protected set; }

        public decimal Calculate(ShoppingBasket basket)
        {
            Total = basket.GroupBy(i => i).Aggregate(0M, (t, g) => { t += g.Key.MultipriceRules.First().Calculate(g.Count()); return t; });

            return Total;

            //Total = 0;
            //foreach(SKU sku in basket)
            //{
            //    Total += sku.UnitPrice;
            //}

            //foreach(PricingRule rule in pricing.AllSKUs.SelectMany(sku => sku.MultipriceRules))
            //{
            //    rule.ApplyTo(Total, basket);
            //}
        }
    }
}
