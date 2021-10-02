using System;

namespace Shops.Tools
{
    public class ExistingProductIdException : Exception
    {
        public ExistingProductIdException(string message)
            : base(message)
        {
        }
    }
}
