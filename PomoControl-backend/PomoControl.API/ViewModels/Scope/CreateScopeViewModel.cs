using PomoControl.API.ViewModels.ScopeItem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PomoControl.API.ViewModels.Scope
{
    public class CreateScopeViewModel
    {
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required!")]
        public string Description { get; set; }

        public int Steps { get; set; }

        public int WorkSeconds { get; set; }

        public int IntervalSeconds { get; set; }

        //public DateTime CreateDate { get; set; }

        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "User code is required!")]
        [MinLength(1, ErrorMessage = "User code must have at least 1 character.")]
        public int UserCode { get; set; }

        public bool Sunday { get; set; }

        public bool Monday { get; set; }

        public bool Tuesday { get; set; }
        
        public bool Wednesday { get; set; }
        
        public bool Thursday { get; set; }
        
        public bool Friday { get; set; }
        
        public bool Saturday { get; set; }
        
        public virtual ICollection<CreateScopeItemViewModel> ScopeItems { get; set; }
    }
}
