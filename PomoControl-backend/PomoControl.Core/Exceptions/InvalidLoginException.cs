using System;

namespace PomoControl.Core.Exceptions
{
    public class InvalidLoginException : Exception
    {
        public InvalidLoginException(string message) : base(message)
        {
            //Save Logs
        }
    }
}
