using ExaminatiomnSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ExaminatiomnSystem.Data
{
    public class Context : DbContext
    {
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Exam> Exams { get; set; }
        
        public DbSet<Instractours> Instractours { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ExaminationDB;Integrated Security=true;encrypt=false")
                .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
                .EnableSensitiveDataLogging();
        }
        public Context()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>()
                 .HasOne(e => e.Instractour)
                 .WithMany(i => i.Exams)
                 .HasForeignKey(e=>e.InstractourID)
                 .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Instractours>()
            //    .HasOne(i => i.Course)
            //    .WithOne(c => c.Instractour)
            //    .HasForeignKey<Course>(c => c.InstractoursID);
        }
    }
}
