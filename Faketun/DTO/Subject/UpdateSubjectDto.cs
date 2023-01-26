namespace Faketun.DTO.Subject;

public class UpdateSubjectDto
{
    public string? Name { get; set; }
    public string? Code { get; set; }
    public int? Credit { get; set; }
    public int? DepartmentId { get; set; }
    public int? SemesterId { get; set; }
}
