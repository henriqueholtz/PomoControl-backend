using System;
using System.Collections.Generic;
using System.Text;

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
