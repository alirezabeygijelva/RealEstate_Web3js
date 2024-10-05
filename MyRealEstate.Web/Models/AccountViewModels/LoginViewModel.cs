using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyRealEstate.Web.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "رایانامه")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string EthAccountAddress { get; set; }

        [Display(Name = "گذرواژه")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
