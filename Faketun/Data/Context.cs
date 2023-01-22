using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Faketun.Models;

public class Context: DbContext
{
    public DbSet<Position> Positions { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Semester> Semesters { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        var connectionStringBuilder = new SqliteConnectionStringBuilder{DataSource = "Faketun.db"};
        builder.UseSqlite(new SqliteConnection(connectionStringBuilder.ToString()));
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Instructor>()
            .HasOne(i => i.Position);

        builder.Entity<Student>()
            .HasOne(s => s.Course);

        builder.Entity<Subject>()
            .HasOne(s => s.Department);
        builder.Entity<Subject>()
            .HasOne(s => s.Semester);
        builder.Entity<Subject>()
            .HasMany(s => s.Instructors)
            .WithMany(i => i.Subjects);
        builder.Entity<Subject>()
            .HasMany(s => s.Students)
            .WithMany(s => s.Subjects);
    }
}
