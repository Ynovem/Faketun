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
    public DbSet<InstructorSubject> InstructorSubject { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        var connectionStringBuilder = new SqliteConnectionStringBuilder{DataSource = "Faketun.db"};
        builder.UseSqlite(new SqliteConnection(connectionStringBuilder.ToString()));
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Instructor>()
            .HasOne(i => i.Position)
            .WithMany(p => p.Instructors)
            .HasForeignKey(i => i.PositionId);
        builder.Entity<Instructor>().HasQueryFilter(p => !p.Deleted);

        builder.Entity<Student>()
            .HasOne(s => s.Course)
            .WithMany(c => c.Students)
            .HasForeignKey(s => s.CourseId);
        builder.Entity<Student>().HasQueryFilter(p => !p.Deleted);

        builder.Entity<Subject>()
            .HasOne(s => s.Department)
            .WithMany(d => d.Subjects)
            .HasForeignKey(s => s.DepartmentId);
        builder.Entity<Subject>()
            .HasOne(s => s.Semester)
            .WithMany(s => s.Subjects)
            .HasForeignKey(s => s.SemesterId);
        // builder.Entity<Subject>()
        //     .HasMany(s => s.Instructors)
        //     .WithMany(i => i.Subjects);
        builder.Entity<Subject>()
            .HasMany(s => s.Students)
            .WithMany(s => s.Subjects);
        builder.Entity<Subject>().HasQueryFilter(p => !p.Deleted);

        builder.Entity<InstructorSubject>()
            .HasKey(i => new {i.InstructorId, i.SubjectId});
        builder.Entity<InstructorSubject>()
            .HasOne<Subject>(join => join.Subject)
            .WithMany(s => s.Instructors)
            .HasForeignKey(join => join.SubjectId);
        builder.Entity<InstructorSubject>()
            .HasOne<Instructor>(join => join.Instructor)
            .WithMany(i => i.Subjects)
            .HasForeignKey(join => join.InstructorId);

        base.OnModelCreating(builder);
    }
}
