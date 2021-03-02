using System;

namespace PomoControl.Service.Exceptions
{
    class ExceptionBLL : Exception
    {
        public ExceptionBLL(string msg) : base(msg)
        {
            //implement logs here
        }
    }
}
