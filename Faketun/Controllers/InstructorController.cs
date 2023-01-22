using Faketun.Models;
using Faketun.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Faketun.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class InstructorController
{
    private UnitOfWork _unitOfWork = new UnitOfWork();

    [HttpGet]
    public IEnumerable<Instructor>? Get()
    {
        return _unitOfWork.InstructorRepository?.GetAll().ToList();
    }

    [HttpGet("{id}")]
    public Instructor? Get(int id)
    {
        return _unitOfWork.InstructorRepository?.GetAll()
            .Where(i => i.Id == id)
            .Include(i => i.Position)
            .First();
    }

    [HttpGet("{id}/semester/{semesterid}", Name = "Subjects")]
    public IEnumerable<Subject>? Subjects(int id, int semesterid)
    {
        return _unitOfWork.SubjectRepository?.GetAll()
            .Where(s => s.Semester.Id.Equals(semesterid))
            .Where(s => s.Instructors.Any(i => i.Id.Equals(id)))
            .ToList();
    }
}
