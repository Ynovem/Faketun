using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Faketun.Models;

public class Course: IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "ID")]
    public int Id { get; set; }

    [DefaultValue(false)]
    public bool Deleted { get; set; }

    public string Name { get; set; } = String.Empty;

    public List<Student> Students { get; set; }
}
