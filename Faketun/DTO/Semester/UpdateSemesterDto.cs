using System.ComponentModel.DataAnnotations;

namespace Faketun.Models;

public class UpdateSemesterDto
{
    public string? Name { get; set; }

    [DataType(DataType.Date)]
    public DateTime? StartDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }
}
