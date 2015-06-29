using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Core
{
    public class SKU : IEquatable<SKU>
    {
        public SKU(string name)
        {
            Name = name;
            MultipriceRules = new List<PricingRule>();
        }
        public string Name { get; private set; }
        public decimal UnitPrice { get; set; }
        public IList<PricingRule> MultipriceRules { get; private set; }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as SKU);
        }

        public bool Equals(SKU other)
        {
            if (other == null) return false;

            return string.Equals(Name, other.Name);
        }
    }
}
