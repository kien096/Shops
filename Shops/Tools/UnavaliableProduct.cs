using System;

namespace Shops.Tools
{
    public class UnavaliableProduct : Exception
    {
        public UnavaliableProduct(string message)
            : base(message)
        {
        }
    }
}
