using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using University_Core.Models;

namespace University.Models
{
    public class UniversityContext : IdentityDbContext<User>
    {
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options){
            Database.EnsureCreated();
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StaffingStructure> StaffingStructures { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Group> Groups { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Составной первичный ключ
            modelBuilder.Entity<StaffingStructure>().HasKey(u => new { u.TeacherId, u.DepartmentId});

            modelBuilder.Entity<User>().HasOne(p => p.Teacher).WithOne().HasForeignKey<User>(p => p.TeacherId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Teacher>().HasOne(p => p.User).WithOne().HasForeignKey<Teacher>(p => p.UserId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}