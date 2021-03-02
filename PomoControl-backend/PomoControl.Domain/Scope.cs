using PomoControl.Domain.Validators;
using System;
using System.Collections.Generic;

namespace PomoControl.Domain
{
    public class Scope : Base
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Steps { get; private set; }
        public int WorkSeconds { get; private set; }
        public int IntervalSeconds { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime StartDate { get; private set; }
        public int UserCode { get; private set; }
        public bool Sunday { get; private set; }
        public bool Monday { get; private set; }
        public bool Tuesday { get; private set; }
        public bool Wednesday { get; private set; }
        public bool Thursday { get; private set; }
        public bool Friday { get; private set; }
        public bool Saturday { get; private set; }
        public virtual ICollection<ScopeItem> ScopeItems { get; private set; }

        protected Scope() { }

        public Scope(string name, string description, int steps, int workSeconds, int intervalSeconds, DateTime createDate, DateTime startDate, int userCode, bool sunday, bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday, ICollection<ScopeItem> scopeItems)
        {
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
            _errors = new List<string>();
        }

        public override bool Validate()
        {
            var validator = new ScopeValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach(var error in validation.Errors)
                {
                    _errors.Add($"{error.ErrorCode.ToString()} - {error.ErrorMessage}");

                    throw new Exception("Some properties are not valid" + _errors[0]);
                }
            }
            return true;
        }
    }
}
