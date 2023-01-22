using Faketun.Models;
using Faketun.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace Faketun.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class StudentController
{
    private UnitOfWork _unitOfWork = new UnitOfWork();

    [HttpGet]
    public IEnumerable<Student>? Get()
    {
        return _unitOfWork.StudentRepository?.GetAll().ToList();
    }
}
