using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyRealEstate.DomainClasses.Estate
{
    public class EstateStatus
    {
        public EstateStatus()
        {

        }
        [Key]
        public int EstateStatusId { get; set; }
        [MaxLength(100)]
        [Required]
        public string StatusName { get; set; }
        public virtual List<Estate> Estates { get; set; }
    }
}
