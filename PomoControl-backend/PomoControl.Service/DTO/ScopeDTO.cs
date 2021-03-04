using PomoControl.Domain;
using System;
using System.Collections.Generic;

namespace PomoControl.Service.DTO
{
    public class ScopeDTO
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
        public virtual ICollection<ScopeItem> ScopeItems { get; set; }
        public ScopeDTO()
        { }

        public ScopeDTO(int code, string name, string description, int steps, int workSeconds, int intervalSeconds, DateTime createDate, DateTime startDate, int userCode, bool sunday, bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday, ICollection<ScopeItem> scopeItems)
        {
            Code = code;
            Name = name;
            Description = description;
            Steps = steps;
            WorkSeconds = workSeconds;
            IntervalSeconds = intervalSeconds;
            CreateDate = createDate;
            StartDate = startDate;
            UserCode = userCode;
            Sunday = sunday;
            Monday = monday;
            Tuesday = tuesday;
            Wednesday = wednesday;
            Thursday = thursday;
            Friday = friday;
            Saturday = saturday;
            ScopeItems = scopeItems;
        }
    }
}
