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
    public IEnumerable<Semester>? Get()
    {
        return _unitOfWork.SemesterRepository?.GetAll().ToList();
    }

    [HttpPost]
    public IActionResult Post([FromBody] NewSemesterDto newSemesterDto)
    {
        _unitOfWork.SemesterRepository.Create(new Semester
        {
            Name = newSemesterDto.Name,
            StartDate = newSemesterDto.StartDate,
            EndDate = newSemesterDto.EndDate,
        });
        return Ok();
    }
}
