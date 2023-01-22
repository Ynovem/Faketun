using Faketun.Models;
using Faketun.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace Faketun.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class SemesterController: ControllerBase
{
    private UnitOfWork _unitOfWork = new UnitOfWork();

    [HttpGet]
    public IEnumerable<Semester>? Get()
    {
        return _unitOfWork.SemesterRepository?.GetAll().ToList();
    }
}
