using Asp.netCoreMVCIntro.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Asp.netCoreMVCIntro.ViewModels
{
    public class CollageViewModel    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Za-z][A-Za-z0-9@#%.&\*]*$", ErrorMessage = "Enter the name of Collage")]
        [Required]
        [Display(Name = "Enter the name of Collage")]
        public string Collage_Name { get; set; }

        [Required]
        [Display(Name = "Enter the Address of Collage")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Enter the Grade of Collage")]
        public string Grade { get; set; }

        [Required]
        [Display(Name = "Enter the Code of Collage")]
        public int Code { get; set; }
    }
}
