using System;

namespace PomoControl.Core.Exceptions
{
    public class RepositoryException : Exception
    {
        public RepositoryException()
        { }
        public RepositoryException(string message) : base(message)
        { /* Gravar logs aqui */ }
        public RepositoryException(string message, Exception ex) : base(message, ex)
        { /* Gravar logs aqui */ }
    }
}
