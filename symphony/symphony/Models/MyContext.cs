using Microsoft.EntityFrameworkCore;

namespace symphony.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) :base(options) { 
        }
        public DbSet<course> tbl_course { get; set; }
        public DbSet<student> tbl_student { get; set; }
        public DbSet<teacher> tbl_teacher { get; set; }

        public DbSet<admin> tbl_admin { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<coursetopic>().HasOne(ct => ct.course).WithMany(c => c.topics).HasForeignKey(ct => ct.course_id);
        }
         
    }
}
