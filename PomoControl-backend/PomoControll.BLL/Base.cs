using System;
using System.Collections.Generic;
using System.Text;

namespace PomoControll.Model
{
    public abstract class Base
    {
        public int Code { get; set; }

        internal List<string> _errors;
        public IReadOnlyCollection<string> Erros => _errors;

        public abstract bool Validate();
    }
}
