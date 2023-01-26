using Faketun.Models;
using Faketun.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace Faketun.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SemesterController: ControllerBase
{
    private UnitOfWork _unitOfWork = new UnitOfWork();

    [HttpGet]
    public IEnumerable<Semester>? Read([FromQuery] bool deleted = false)
    {
        return _unitOfWork.SemesterRepository?.GetAll(deleted).ToList();
    }

    [HttpPost]
    public IActionResult Create([FromBody] NewSemesterDto dto)
    {
        var result = _unitOfWork.SemesterRepository?.Create(new Semester
        {
            Name = dto.Name,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
        });

        if (result == null || result.Result == false)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateSemesterDto dto)
    {
        Semester? semester = _unitOfWork.SemesterRepository?.GetById(id);
        if (semester == null)
        {
            return NotFound();
        }

        semester.Name = dto.Name ?? semester.Name;
        semester.StartDate = dto.StartDate.GetValueOrDefault(semester.StartDate);
        semester.EndDate = dto.EndDate.GetValueOrDefault(semester.EndDate);

        var result = _unitOfWork.SemesterRepository?.Update(id, semester);
        if (result == null || result.Result == false)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _unitOfWork.SemesterRepository?.LogicalDelete(id);
        if (result == null || result.Result == false)
        {
            return NotFound();
        }

        return Ok();
    }
}
