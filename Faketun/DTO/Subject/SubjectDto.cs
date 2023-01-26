namespace Faketun.DTO.Subject;

public class SubjectDto
{
    public SubjectDto(Models.Subject subject)
    {
        Id = subject.Id;
        Name = subject.Name;
        Code = subject.Code;
        Credit = subject.Credit;
        Console.Write(subject.SemesterId);
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public int Credit { get; set; }
}
