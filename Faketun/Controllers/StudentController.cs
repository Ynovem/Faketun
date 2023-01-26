using Faketun.DTO.Student;
using Faketun.DTO.Subject;
using Faketun.Models;
using Faketun.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace Faketun.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController: ControllerBase
{
    private UnitOfWork _unitOfWork = new UnitOfWork();

    [HttpGet]
    public IEnumerable<Student>? Read([FromQuery] bool deleted = false)
    {
        return _unitOfWork.StudentRepository?.GetAll(deleted).ToList();
    }

    [HttpGet("{id}/subjects/{semesterid}")]
    public IEnumerable<SubjectDto>? Subjects(int id, int semesterid, [FromQuery] bool deleted = false)
    {
        return _unitOfWork.SubjectRepository?.GetAll(deleted)
            .Where(s => s.Semester.Id.Equals(semesterid))
            .Where(s => s.Students.Any(i => i.Id.Equals(id)))
            .ToList()
            .ConvertAll(s => new SubjectDto(s));
    }

    [HttpPost]
    public IActionResult Create([FromBody] NewStudentDto dto)
    {
        var result = _unitOfWork.StudentRepository?.Create(new Student
        {
            Email = dto.Email,
            Name = dto.Name,
            Neptun = dto.Neptun,
            CourseId = dto.CourseId,
        });

        if (result == null || result.Result == false)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateStudentDto dto)
    {
        Student? student = _unitOfWork.StudentRepository?.GetById(id);
        if (student == null)
        {
            return NotFound();
        }

        student.Name = dto.Name ?? student.Name;
        student.Neptun = dto.Neptun ?? student.Neptun;
        student.Email = dto.Email ?? student.Email;
        student.CourseId = dto.CourseId.GetValueOrDefault(student.CourseId);

        var result = _unitOfWork.StudentRepository?.Update(id, student);
        if (result == null || result.Result == false)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _unitOfWork.StudentRepository?.LogicalDelete(id);
        if (result == null || result.Result == false)
        {
            return NotFound();
        }

        return Ok();
    }
}
