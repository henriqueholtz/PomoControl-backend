using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomoControl.API.ViewModels.ScopeItem
{
    public class CreateScopeItemViewModel
    {
        //public int ScopeCode { get; set; }
        //public Scope Scope { get; set; }
        public DateTime Start { get; set; }
        //public DateTime End { get; set; }
        public byte Type { get; set; } //EnumTypeScope
        public string Commentary { get; set; }
    }
}
