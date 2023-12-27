using Asp.netCoreMVCIntro.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Asp.netCoreMVCIntro.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public StudentViewModel()
        {
            collages = new List<Collage>();
        }

        [Required(ErrorMessage = "Please enter First Name")]
        [Display(Name = "Please enter First Name")]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "Please enter Last Name")]
        [Display(Name = "Please enter Last Name")]
        public string Last_Name { get; set; }

        [Required(ErrorMessage = "Please enter Percentage")]
        [Display(Name = "Please enter Percentage")]
        public int Percentage { get; set; }

        [Required(ErrorMessage = "Please enter DOB")]
        [Display(Name = "Please enter DOB")]
        public DateTime DOB { get; set; }
        public int CollageId { get; set; }
        public List<Collage> collages { get; set; }
    }
}
