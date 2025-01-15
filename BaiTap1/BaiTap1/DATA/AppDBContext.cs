using BaiTap1.Models;
using Microsoft.EntityFrameworkCore;

namespace BaiTap1.DATA
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<student> student { get; set; }
        public DbSet<course> course { get; set; }
        public DbSet<enrollment> enrollment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình quan hệ 1 - N giữa Course và Enrollment
            modelBuilder.Entity<enrollment>()
                .HasOne(e => e.course)
                .WithMany(c => c.enrollments)
                .HasForeignKey(e => e.courseid);

            // Cấu hình quan hệ 1 - N giữa Student và Enrollment
            modelBuilder.Entity<enrollment>()
                .HasOne(e => e.student)
                .WithMany(s => s.enrollments)
                .HasForeignKey(e => e.studentid);
        }
    }
}
