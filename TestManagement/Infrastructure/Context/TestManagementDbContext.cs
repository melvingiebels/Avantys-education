using CQS.Domain;
using CQS.Domain.Questions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class TestManagementDbContext : DbContext
{
    public TestManagementDbContext(DbContextOptions<TestManagementDbContext> options) : base(options)
    {
    }

    public DbSet<Test> Tests { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<McQuestion?> McQuestions { get; set; }
    public DbSet<OpenQuestion> OpenQuestions { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<TestQuestions> TestQuestions { get; set; }
    public DbSet<StudentsTests> StudentsTests { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<McQuestion>().ToTable("McQuestions");
        modelBuilder.Entity<OpenQuestion>().ToTable("OpenQuestions");

        modelBuilder.Entity<Test>()
            .HasMany(e => e.Questions)
            .WithMany(e => e.Tests)
            .UsingEntity<TestQuestions>();

        modelBuilder.Entity<Student>()
            .HasMany(e => e.Tests)
            .WithMany(e => e.Students)
            .UsingEntity<StudentsTests>();
    }
}