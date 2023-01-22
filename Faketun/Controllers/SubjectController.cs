using Faketun.Models;
using Faketun.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace Faketun.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class SubjectController: ControllerBase
{
    private UnitOfWork _unitOfWork = new UnitOfWork();

    [HttpGet]
    public IEnumerable<Subject>? Get()
    {
        return _unitOfWork.SubjectRepository?.GetAll().ToList();
    }
}
