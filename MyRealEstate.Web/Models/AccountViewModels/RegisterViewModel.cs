using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyRealEstate.Web.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "رایانامه")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = " {0} باید دست کم {2} و دست بیش {1} کاراکتر باشد.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "گذرواژه")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار گذرواژه")]
        [Compare("Password", ErrorMessage = "گذرواژه و تکرار آن یکی نیست!")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید")]
        [Display(Name = "نام")]
        [MaxLength(50)]
        public string FName { get; set; }
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید")]
        [Display(Name = "نام خانوادگی")]
        [MaxLength(50)]
        public string LName { get; set; }
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید")]
        [Display(Name = "تلفن همراه")]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        [Display(Name = "نشانی")]
        [MaxLength(500)]
        public string PostalAddress { get; set; }
        [Display(Name = "نشانی حساب اتریوم")]
        [MaxLength(100)]
        public string EthAccountAddress { get; set; }
        [Display(Name = "فعالیت به عنوان مشاور")]
        public bool IsConsultant { get; set; }
    }
}
