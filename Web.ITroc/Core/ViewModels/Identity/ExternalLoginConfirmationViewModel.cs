using System.ComponentModel.DataAnnotations;

namespace Web.ITroc.Core.ViewModels.Identity
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Courrier électronique")]
        public string Email { get; set; }
    }
}