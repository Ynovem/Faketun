using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Faketun.Models;

public class Subject: IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "ID")]
    public int Id { get; set; }

    [DefaultValue(false)]
    public bool Deleted { get; set; }

    public string Name { get; set; } = String.Empty;
    public string Code { get; set; } = String.Empty;
    public int Credit { get; set; }

    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    public int SemesterId { get; set; }
    public Semester Semester { get; set; }
    public List<InstructorSubject> Instructors { get; set; }
    public List<Student> Students { get; set; }
}
