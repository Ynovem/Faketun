using Faketun.Models;
using Faketun.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

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
}
