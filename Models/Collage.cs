using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.netCoreMVCIntro.Models
{
    public class Collage
    {
        public int Id { get; set; } 
        public string Collage_Name { get; set; }
        public string Address { get; set; }

        public string Grade { get; set; }

        public int Code { get; set; }
        public List<Student> Students { get; set; }
    }
}
