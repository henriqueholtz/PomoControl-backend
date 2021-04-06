using System;
using System.Net;

namespace PomoControl.Core.Exceptions
{
    public class InvalidTokenException : PomoControlException
    {
        public InvalidTokenException(string message = "Invalid Token!") : base(message, HttpStatusCode.Unauthorized)
        { }
    }
}
