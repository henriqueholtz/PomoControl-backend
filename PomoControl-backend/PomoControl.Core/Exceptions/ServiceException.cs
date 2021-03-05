using System;
using System.Collections.Generic;
using System.Text;

namespace PomoControl.Core.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException()
        { }
        public ServiceException(string message) : base(message)
        { /* Gravar logs aqui */ }
        public ServiceException(string message, Exception ex) : base(message, ex)
        { /* Gravar logs aqui */ }
    }
}
