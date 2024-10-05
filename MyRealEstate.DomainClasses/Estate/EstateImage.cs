using System;
using System.Collections.Generic;
using System.Text;


namespace MyRealEstate.DomainClasses.Estate
{
    public class EstateImage
    {
        public int EstateImageId { get; set; }
        public int EstateId { get; set; }
        public string EstateImg { get; set; }

        public virtual Estate Estate { get; set; }
    }
}
