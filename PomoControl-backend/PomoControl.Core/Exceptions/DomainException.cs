using System;
using System.Collections.Generic;

namespace PomoControl.Core.Exceptions
{
    public class DomainException : Exception
    {
        internal List<string> _errors = new List<string>();
        public IReadOnlyList<string> Errors => _errors;
        public DomainException()
        { /* Gravar logs aqui */ }
        public DomainException(string message, List<string> errors) : base(message)
        {
            _errors = errors;
        }
        public DomainException(string message) : base(message)
        { /* Gravar logs aqui */ }
        public DomainException(string message, Exception innerException) : base(message, innerException)
        { /* Gravar logs aqui */ }
    }
}
