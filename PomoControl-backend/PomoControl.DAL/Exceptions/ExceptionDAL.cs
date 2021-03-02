using System;

namespace PomoControl.Infraestructure.Exceptions
{
    class ExceptionDAL : Exception
    {
        public ExceptionDAL(string msg) : base(msg)
        {
            //insert logs here
        }
    }
}
