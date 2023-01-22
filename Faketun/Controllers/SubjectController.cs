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
    public IEnumerable<SubjectDto>? Get()
    {
        return _unitOfWork.SubjectRepository?.GetAll()
            .ToList()
            .ConvertAll(s => new SubjectDto(s));
    }

    [HttpPost]
    public IActionResult Create([FromBody] NewSubjectDto newSubjectDto)
    {
        _unitOfWork.SubjectRepository?.Create(new Subject
        {
            Name = newSubjectDto.Name,
            Code = newSubjectDto.Code,
            Credit = newSubjectDto.Credit,
        });
        return Ok();
    }
}
