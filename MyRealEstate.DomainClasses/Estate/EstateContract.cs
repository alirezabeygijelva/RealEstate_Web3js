using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;

namespace MyRealEstate.DomainClasses.Estate
{
    public class EstateContract
    {
        public int EstateContractId { get; set; }
        public int EstateId { get; set; }

        public string OwnerUserId { get; set; }
         public string BuyerUserId { get; set; }
        public string SellerUserId { get; set; }
        public bool BuyerOK { get; set; }
        public bool SellerOK { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? BuyerOKTime { get; set; }
         [Column(TypeName = "smalldatetime")]
        public DateTime? SellerOKTime { get; set; }
         [Column(TypeName = "smalldatetime")]
        public DateTime SaveTime { get; set; }
         public string Note { get; set; }
        [Display(Name = "Tokens ")]
        public int Amount { get; set; }
        public virtual Estate Estate { get; set; }
    }
}
