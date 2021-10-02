using System;

namespace Shops.Tools
{
    public class ExistingShopIdException : Exception
    {
        public ExistingShopIdException(string message)
            : base(message)
        {
        }
    }
}
