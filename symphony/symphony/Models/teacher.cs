using System.ComponentModel.DataAnnotations;

namespace symphony.Models
{
    public class teacher
    {
        [Key]
        public int teacehr_id { get; set; }
        public string? teacher_Name { get; set; }
        public string? teacher_gmail { get; set; }
        public string? teacher_password { get; set; }
        public int? teacher_phone { get; set; }
        public int? teacher_age { get; set; }

    }
}
