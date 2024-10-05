using System;
using System.Collections.Generic;
using System.Text;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace MyRealEstate.Services.Services
{
    [FunctionOutput]
   public class OutputDocument
    {
        [Parameter("bool", "Result", 1)]
        public bool Result { get; set; }
    }
}
