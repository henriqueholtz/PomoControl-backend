using PomoControll.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PomoControll.Model
{
    public class ScopeItem
    {
        public int ScopeCode { get; set; }
        public int ItemCode { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public EnumTypeScope Type{ get; set; }
    }
}
