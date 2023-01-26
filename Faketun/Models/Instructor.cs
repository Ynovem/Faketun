using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Faketun.Models;

public class Instructor: IEntity
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

    public int PositionId { get; set; }
    public Position Position { get; set; }
    public List<InstructorSubject> Subjects { get; set; }
}
