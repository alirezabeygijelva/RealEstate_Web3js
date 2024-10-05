using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyRealEstate.DomainClasses.Admin
{
    public class Neighborhood
    {
        public Neighborhood()
        {

        }
        [Key]
        public int NeighborhoodId { get; set; }
        [Display(Name = "City ")]
        [Required(ErrorMessage = "Please Fill {0} Filed ")]
        public int CityId { get; set; }
        [Display(Name = "Neighbrohood ")]
        [Required(ErrorMessage = "Please Fill {0} Filed ")]
        [MaxLength(100)]
        public string NeighborhoodName { get; set; }
        [Display(Name = " City")]
        public virtual City City { get; set; }
        public virtual List<Estate.Estate> Estates { get; set; }
    }
}
