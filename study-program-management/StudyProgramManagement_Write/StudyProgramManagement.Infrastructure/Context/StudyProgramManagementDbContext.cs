using Microsoft.EntityFrameworkCore;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Infrastructure.Context;

public class StudyProgramManagementDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Lecture> Lectures { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<StudyProgram> StudyPrograms { get; set; }
    public DbSet<TeacherModules> TeacherModules { get; set; }
    public DbSet<LecturesSchedule?> LecturesSchedule { get; set; }

    public StudyProgramManagementDbContext(DbContextOptions<StudyProgramManagementDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Module>()
            .HasMany(e => e.Teachers)
            .WithMany(e => e.Modules)
            .UsingEntity<TeacherModules>();

        modelBuilder.Entity<LecturesSchedule>()
            .HasOne(ls => ls.Lecture)
            .WithMany()
            .HasForeignKey(c => c.Lecture);

    }
}