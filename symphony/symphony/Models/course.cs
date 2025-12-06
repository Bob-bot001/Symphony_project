using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace symphony.Models
{
    public class course
    {
        [Key]
        public int course_Id { get; set; }

        public string? course_name { get; set; }

        public string? course_description { get; set; }

       public List<coursetopic> topics { get; set; }
    }
}
