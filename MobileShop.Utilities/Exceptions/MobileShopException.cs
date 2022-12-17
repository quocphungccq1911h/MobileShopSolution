using System;

namespace MobileShop.Utilities.Exceptions
{
    public class MobileShopException : Exception
    {
        public MobileShopException()
        {

        }
        public MobileShopException(string message) : base(message)
        {

        }
        public MobileShopException(string message, Exception inner) : base (message,inner)
        {

        }
    }
}
