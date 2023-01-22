using System.ComponentModel.DataAnnotations;

namespace Faketun.Models;

public class NewSemesterDto
{
    public string Name { get; set; } = String.Empty;

    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }
}
