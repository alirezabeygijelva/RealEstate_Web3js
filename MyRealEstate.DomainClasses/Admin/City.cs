using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyRealEstate.DomainClasses.Admin
{
    public class City
    {
        public City()
        {

        }
        [Key]
        public int CityId { get; set; }
        [Display(Name = "State ")]
        [Required(ErrorMessage = "Please Fill {0} Filed ")]
        public int StateId { get; set; }
        [Display(Name = "City ")]
        [Required(ErrorMessage = "Please Fill {0} Filed ")]
        [MaxLength(100)]
        public string CityName { get; set; }
        [Display(Name = "State ")]
        public virtual State State { get; set; }
        public virtual List<Neighborhood> Neighborhoods { get; set; }
    }
}
