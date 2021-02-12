using System;

namespace PomoControl.DAL.Exceptions
{
    class ExceptionDAL : Exception
    {
        public ExceptionDAL(string msg) : base(msg)
        {
            //insert logs here
        }
    }
}
