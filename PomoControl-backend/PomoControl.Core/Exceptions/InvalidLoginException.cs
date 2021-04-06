using System.Net;

namespace PomoControl.Core.Exceptions
{
    public class InvalidLoginException : PomoControlException
    {
        public InvalidLoginException(string message = DefaultErrorMessages.DefaultErrorMessages.InvalidLogin) : base(message, HttpStatusCode.Unauthorized)
        {
            //Save Logs
        }
    }
}
