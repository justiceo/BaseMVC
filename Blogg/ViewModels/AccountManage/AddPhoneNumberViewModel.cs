using System.ComponentModel.DataAnnotations;

namespace Blogg.ViewModels.AccountManage
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}