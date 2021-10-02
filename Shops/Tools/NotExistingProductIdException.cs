using System;

namespace Shops.Tools
{
    public class NotExistingProductIdException : Exception
    {
        public NotExistingProductIdException(string message)
            : base(message)
        {
        }
    }
}
