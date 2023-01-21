using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Faketun.Models;

public class Subject: IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "ID")]
    public int Id { get; set; }
    
    public string Name { get; set; } = String.Empty;
    public string Code { get; set; } = String.Empty;
    public int Credit { get; set; }

    public Department Department { get; set; }
    public List<Instructor> Instructors { get; set; }
    public List<Student> Students { get; set; }
    public Semester Semester { get; set; }
}
