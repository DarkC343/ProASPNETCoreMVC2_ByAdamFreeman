using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpLanguageFeatures.Models
{
    public static class MyExtentionMethods
    {
        public static decimal TotalPrices(this ShoppingCart cartParam)
        {
            decimal total = 0;
            foreach (Laptop device in cartParam.Laptops)
            {
                total += device?.Price ?? 0;
            }
            return total;
        }
    }
}
