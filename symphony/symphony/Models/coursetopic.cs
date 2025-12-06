using System.ComponentModel.DataAnnotations;

namespace symphony.Models
{
    public class coursetopic
    {
        [Key]
        public int ct_id { get; set; }
        public string ct_name { get; set; }

        //yahan lgaeyingy frogin keys hahaha...
        public int course_id { get; set; }
        public course course { get; set; }


    }
}
