using System;
using System.Collections.Generic;

namespace PomoControl.Domain
{
    public class ScopeItem : Base
    {
        public int ScopeCode { get; private set; }
        public Scope Scope { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public byte Type{ get; private set; } //EnumTypeScope
        public string Commentary { get; private set; }

        protected ScopeItem() { }
        public ScopeItem(int scopeCode, Scope scope, DateTime start, DateTime end, byte type, string commentary)
        {
            ScopeCode = scopeCode;
            Scope = scope;
            Start = start;
            End = end;
            Type = type;
            Commentary = commentary;
            _errors = new List<string>();
        }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
