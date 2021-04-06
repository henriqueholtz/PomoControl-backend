using System;
using System.Net;

namespace PomoControl.Core.Exceptions
{
    public class RepositoryException : PomoControlException
    {
        public RepositoryException(string message = "An error ourred in Repository.") : base(message, HttpStatusCode.InternalServerError)
        { }
    }
}
