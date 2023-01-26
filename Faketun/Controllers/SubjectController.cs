using Faketun.DTO.Subject;
using Faketun.Models;
using Faketun.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace Faketun.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubjectController: ControllerBase
{
    private UnitOfWork _unitOfWork = new UnitOfWork();

    [HttpGet]
    public IEnumerable<SubjectDto>? Read(bool deleted)
    {
        return _unitOfWork.SubjectRepository?.GetAll(deleted)
            .ToList()
            .ConvertAll(s => new SubjectDto(s));
    }

    [HttpPost]
    public IActionResult Create([FromBody] NewSubjectDto dto)
    {
        var result = _unitOfWork.SubjectRepository?.Create(new Subject
        {
            Name = dto.Name,
            Code = dto.Code,
            Credit = dto.Credit,
            DepartmentId = dto.DepartmentId,
            SemesterId = dto.SemesterId,
        });

        if (result == null || result.Result == false)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateSubjectDto dto)
    {
        Subject? subject =  _unitOfWork.SubjectRepository?.GetById(id);
        if (subject == null)
        {
            return NotFound();
        }

        subject.Name = dto.Name ?? subject.Name;
        subject.Code = dto.Code ?? subject.Code;
        subject.Credit = dto.Credit.GetValueOrDefault(subject.Credit);
        subject.DepartmentId = dto.DepartmentId.GetValueOrDefault(subject.DepartmentId);
        subject.SemesterId = dto.SemesterId.GetValueOrDefault(subject.SemesterId);

        var result = _unitOfWork.SubjectRepository?.Update(id, subject);
        if (result == null || result.Result == false)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _unitOfWork.SubjectRepository?.LogicalDelete(id);
        if (result == null || result.Result == false)
        {
            return NotFound();
        }

        return Ok();
    }
}
