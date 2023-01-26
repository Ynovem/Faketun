using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Faketun.Models;

public class Student: IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "ID")]
    public int Id { get; set; }

    [DefaultValue(false)]
    public bool Deleted { get; set; }

    public string Neptun { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;

    public int CourseId { get; set; }
    public Course Course { get; set; }
    public List<Subject> Subjects { get; set; }
}
