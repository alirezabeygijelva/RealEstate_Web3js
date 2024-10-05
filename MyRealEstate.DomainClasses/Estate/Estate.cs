using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyRealEstate.DomainClasses.Estate
{
    public class Estate
    {
        public Estate()
        {

        }
        [Key]
        public int EstateId { get; set; }

        public int NeighborhoodId { get; set; }
        public int EstateStatusId { get; set; }
        [MaxLength(500)]
        public string Title { get; set; }
         [DataType(DataType.MultilineText)]
        public string Note { get; set; }
         public decimal Area { get; set; }
         public byte RoomNo { get; set; }
         public Int16 ConstructionYear { get; set; }
        public Int64 Price { get; set; }
        [DataType(DataType.Upload)]
        public List<EstateImage> EstateImages { get; set; }
        public string EstateLogo { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime RegDate { get; set; }
        public bool Enable { get; set; }
        public virtual Admin.Neighborhood Neighborhood { get; set; }
       public virtual EstateStatus EstateStatus { get; set; }
    }
}
