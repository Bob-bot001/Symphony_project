using System.ComponentModel.DataAnnotations;

namespace symphony.Models
{
    public class student
    {
        [Key]
        public int student_Id { get; set; }
        public string? student_Name { get; set; }
        public string? student_email { get; set; }
        public int student_phone { get; set; }
        public string? student_address { get; set; }

    }
}
