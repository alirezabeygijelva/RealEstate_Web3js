using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyRealEstate.DomainClasses.Admin
{
    public class State
    {
        public State()
        {

        }
        [Key]
        public int StateId { get; set; }
        [Display(Name ="State ")]
        [Required(ErrorMessage = "Please Fill {0} Filed ")]
        [MaxLength(100)]
        public string StateName { get; set; }
        public virtual List<City> Cities { get; set; }
    }
}
