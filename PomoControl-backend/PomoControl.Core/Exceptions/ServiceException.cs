using System.Net;

namespace PomoControl.Core.Exceptions
{
    public class ServiceException : PomoControlException
    {
        public ServiceException(string message = "An error ocurrer in Service.") : base(message, HttpStatusCode.InternalServerError)
        { }
    }
}
