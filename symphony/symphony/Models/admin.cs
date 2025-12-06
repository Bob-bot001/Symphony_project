using System.ComponentModel.DataAnnotations;

namespace symphony.Models
{
    public class admin
    {
        [Key]
        public int admin_id { get; set; }
        public string admin_username { get; set; }
        public string admin_password { get; set; }
    }
}
