using System;
using System.Collections.Generic;
using System.Text;

namespace PomoControl.BLL.Exceptions
{
    class ExceptionBLL : Exception
    {
        public ExceptionBLL(string msg) : base(msg)
        {
            //implement logs here
        }
    }
}
