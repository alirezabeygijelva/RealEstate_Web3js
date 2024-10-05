using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MyRealEstate.DomainClasses.Estate
{
    public class RequestEstate
    {
        public int RequestEstateId { get; set; }
        public string SaveUserId { get; set; }
        public int EstateId { get; set; }
        public DateTime SaveTime  { get; set; }
        public string Note { get; set; }
        public virtual Estate Estate { get; set; }
    }
}
