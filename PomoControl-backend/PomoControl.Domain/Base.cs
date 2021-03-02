using System.Collections.Generic;

namespace PomoControl.Domain
{
    public abstract class Base
    {
        public int Code { get; set; }

        internal List<string> _errors;
        public IReadOnlyCollection<string> Erros => _errors;

        public abstract bool Validate();
    }
}
