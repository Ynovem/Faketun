using Faketun.DTO.Instructor;
using Faketun.DTO.Subject;
using Faketun.Models;
using Faketun.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Faketun.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstructorController: ControllerBase
{
    private UnitOfWork _unitOfWork = new UnitOfWork();

    [HttpGet]
    public IEnumerable<Instructor>? Read([FromQuery] bool deleted = false)
    {
        return _unitOfWork.InstructorRepository?.GetAll(deleted).ToList();
    }

    [HttpGet("{id}")]
    public Instructor? Read(int id, [FromQuery] bool deleted = false)
    {
        return _unitOfWork.InstructorRepository?.GetAll(deleted)
            .Where(i => i.Id == id)
            .Include(i => i.Position)
            .First();
    }

    [HttpPost]
    public IActionResult Create([FromBody] NewInstructorDto dto)
    {
        Position? position = _unitOfWork.PositionRepository?.GetById(dto.PositionId);
        if (position == null)
        {
            return BadRequest();
        }

        var result = _unitOfWork.InstructorRepository?.Create(new Instructor
        {
            Email = dto.Email,
            Name = dto.Name,
            Neptun = dto.Neptun,
            PositionId = dto.PositionId
        });

        if (result == null || result.Result == false)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateInstructorDto dto)
    {
        Instructor? instructor = _unitOfWork.InstructorRepository?.GetById(id);
        if (instructor == null)
        {
            return NotFound();
        }

        instructor.Email = dto.Email ?? instructor.Email;
        instructor.Name = dto.Name ?? instructor.Name;
        instructor.Neptun = dto.Neptun ?? instructor.Neptun;
        instructor.PositionId = dto.PositionId ?? instructor.PositionId;

        var result = _unitOfWork.InstructorRepository?.Update(id, instructor);
        if (result == null || result.Result == false)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpPut("{id}/subject/{subjectid}")]
    public IActionResult addSubject(int id, int subjectid)
    {
        var result = _unitOfWork.InstructorSubjectRepository?.Assign(id, subjectid);
        if (result == null || result.Result == false)
        {
            return Conflict();
        }

        return Ok();
    }

    [HttpDelete("{id}/subject/{subjectid}")]
    public IActionResult removeSubject(int id, int subjectid)
    {
        var result = _unitOfWork.InstructorSubjectRepository?.Unassign(id, subjectid);
        if (result == null || result.Result == false)
        {
            return Conflict();
        }

        return Ok();
    }

    [HttpGet("{id}/subjects/{semesterid}")]
    public IEnumerable<SubjectDto>? Subjects(int id, int semesterid)
    {
        return _unitOfWork.InstructorSubjectRepository?.GetAll()
            .Where(i => i.InstructorId == id)
            .Include(i => i.Subject)
            .Where(i  => i.Subject.SemesterId == semesterid)
            .ToList()
            .ConvertAll(s => new SubjectDto(s.Subject));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _unitOfWork.InstructorRepository?.LogicalDelete(id);
        if (result == null || result.Result == false)
        {
            return NotFound();
        }

        return Ok();
    }
}
