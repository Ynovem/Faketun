using Faketun.Models;
using Faketun.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace Faketun.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController
{
    private UnitOfWork _unitOfWork = new UnitOfWork();

    [HttpGet]
    public IEnumerable<Student>? Get()
    {
        return _unitOfWork.StudentRepository?.GetAll().ToList();
    }

    [HttpGet("{id}/subjects/{semesterid}")]
    public IEnumerable<Subject>? Subjects(int id, int semesterid)
    {
        return _unitOfWork.SubjectRepository?.GetAll()
            .Where(s => s.Semester.Id.Equals(semesterid))
            .Where(s => s.Students.Any(i => i.Id.Equals(id)))
            .ToList();
    }
}
