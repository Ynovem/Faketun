using System.Text.Json.Serialization;
using Faketun;
using Faketun.Models;
using Microsoft.AspNetCore;

public class Program
{
    public static void Main(string[] args)
    {
        using (var db = new Context())
        {
            // Add Sample data
            if (!db.Courses.Any() &&
                !db.Courses.Any() &&
                !db.Departments.Any() &&
                !db.Semesters.Any() &&
                !db.Instructors.Any() &&
                !db.Students.Any())
            {
                var positions = new List<Position>
                {
                    new Position() {Name = "docens"},
                    new Position() {Name = "adjunktus"},
                    new Position() {Name = "mesteroktató"},
                    new Position() {Name = "ügyvivő szakértő"},
                    new Position() {Name = "tanársegéd"},
                    new Position() {Name = "egyéb"},
                };
                db.Positions.AddRange(positions);
                db.SaveChanges();

                var courses = new List<Course>
                {
                    new Course() {Name = "Mérnökinformatikus Msc"},
                    new Course() {Name = "Programtervező informatikus Msc"},
                    new Course() {Name = "Mérnökinformatikus Bsc"},
                    new Course() {Name = "Programtervező informatikus Bsc"},
                    new Course() {Name = "Gazdaságinformatikus Bsc"},
                };
                db.Courses.AddRange(courses);
                db.SaveChanges();

                var departments = new List<Department>
                {
                    new Department() {Name = "VIRT"},
                    new Department() {Name = "RSZT"},
                    new Department() {Name = "Matematika"},
                };
                db.Departments.AddRange(departments);
                db.SaveChanges();

                var semesters = new List<Semester>
                {
                    new Semester()
                    {
                        Name = "2022/23/1",
                        StartDate = new DateTime(2022, 9, 1),
                        EndDate = new DateTime(2023, 1, 31)
                    },
                    new Semester()
                    {
                        Name = "2022/23/2",
                        StartDate = new DateTime(2023, 2, 1),
                        EndDate = new DateTime(2023, 6, 30)
                    }
                };
                db.Semesters.AddRange(semesters);
                db.SaveChanges();

                var instructors = new List<Instructor>()
                {
                    new Instructor()
                    {
                        Position = db.Positions.Find(1),
                        Name = "Instructor1",
                        Email = "instructor1@email",
                        Neptun = "INSTR1",
                    },
                    new Instructor()
                    {
                        Position = db.Positions.Find(2),
                        Name = "Instructor2",
                        Email = "instructor2@email",
                        Neptun = "INSTR2",
                    },
                };
                db.Instructors.AddRange(instructors);
                db.SaveChanges();

                var students = new List<Student>()
                {
                    new Student()
                    {
                        Name = "Student1",
                        Email = "Email1",
                        Course = db.Courses.Find(1),
                        Neptun = "STUDE1",
                    },
                    new Student()
                    {
                        Name = "Student2",
                        Email = "Email2",
                        Course = db.Courses.Find(2),
                        Neptun = "STUDE2",
                    },
                };
                db.Students.AddRange(students);
                db.SaveChanges();

                db.Subjects.AddRange(new List<Subject>
                {
                    new Subject
                    {
                        Semester = semesters[0],
                        Department = departments[0],
                        Name = "Subject 1",
                        Code = "Subj#1",
                        Credit = 1,
                        Instructors = new List<Instructor>{},
                        Students = new List<Student>{},
                    },
                    new Subject
                    {
                        Semester = semesters[0],
                        Department = departments[0],
                        Name = "Subject 2",
                        Code = "Subj#2",
                        Credit = 2,
                        Instructors = new List<Instructor>{instructors[0]},
                        Students = new List<Student>{students[0]},
                    },
                    new Subject
                    {
                        Semester = semesters[0],
                        Department = departments[0],
                        Name = "Subject 3",
                        Code = "Subj#3",
                        Credit = 3,
                        Instructors = new List<Instructor>{instructors[1]},
                        Students = new List<Student>{students[1]},
                    },
                    new Subject
                    {
                        Semester = semesters[0],
                        Department = departments[0],
                        Name = "Subject 4",
                        Code = "Subj#4",
                        Credit = 4,
                        Instructors = new List<Instructor>{instructors[0], instructors[1]},
                        Students = new List<Student>{students[0], students[1]},
                    },
                });
                db.SaveChanges();
            }
        }
        // CreateWebHostBuilder(args).Build().Run();
        var builder = WebApplication.CreateBuilder(args);

        // configure services
        builder.Services.AddControllers().AddJsonOptions(
            x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
        );

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.DocumentFilter<LowercaseDocumentFilter>();
        });
        // configure services-end

        var app = builder.Build();

        // configure HTTP pipeline
        app.UseSwagger();
        app.UseSwaggerUI();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }


        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCookiePolicy();

        app.UseRouting();


        app.MapControllerRoute(
            name: "default",
            pattern: "{controller}/{action}/{id?}"
        );

        app.Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args)
    {
        return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
    }
}
