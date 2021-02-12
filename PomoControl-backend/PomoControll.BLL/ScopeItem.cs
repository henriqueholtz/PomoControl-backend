using System;

namespace PomoControll.Model
{
    public class ScopeItem
    {
        public int ScopeCode { get; set; }
        public int ItemCode { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public byte Type{ get; set; } //EnumTypeScope
        public string Commentary { get; set; }
    }
}
