using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Faketun.Models;

public class Position: IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "ID")]
    public int Id { get; set; }

    public string Name { get; set; } = String.Empty;

    public IList<Instructor> Instructors { get; set; } = new List<Instructor>();
}
