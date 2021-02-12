using System;

namespace PomoControll.Model
{
    public class Scope
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Steps { get; set; }
        public int WorkSeconds { get; set; }
        public int IntervalSeconds { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime StartDate { get; set; }
        public int UserCode { get; set; }
        public bool Sunday { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
    }
}
