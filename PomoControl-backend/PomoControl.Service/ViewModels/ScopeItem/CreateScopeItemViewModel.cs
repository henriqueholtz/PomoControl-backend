using PomoControl.Core.Enums.Messages;
using System;
using System.ComponentModel.DataAnnotations;

namespace PomoControl.Service.ViewModels.ScopeItem
{
    public class CreateScopeItemViewModel
    {
        [Required(ErrorMessage = ErrorMessagesStatic.Required)]
        [Range(1, int.MaxValue, ErrorMessage = "Code must be between 1 and 2147483647.")]
        public int ScopeCode { get; set; }
        //public Scope Scope { get; set; }
        public DateTime Start { get; set; }
        //public DateTime End { get; set; }
        public byte Type { get; set; } //EnumTypeScope
        public string Commentary { get; set; }
    }
}
