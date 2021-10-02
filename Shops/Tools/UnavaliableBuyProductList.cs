using System;

namespace Shops.Tools
{
    public class UnavaliableBuyProductList : Exception
    {
        public UnavaliableBuyProductList(string message)
            : base(message)
        {
        }
    }
}
