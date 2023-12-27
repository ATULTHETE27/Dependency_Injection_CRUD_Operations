
namespace Asp.netCoreMVCIntro.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int Percentage { get; set; }
        public DateTime DOB { get; set; }
        //Setup relationship with Collage model/table        
        public int CollageId { get; set; } //Foreign Key
        public Collage Collage { get; set; } //Reference navigaton property
    }
}
