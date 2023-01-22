using Faketun.Models;

namespace Faketun.Repositories;

public class StudentRepository: GenericRepository<Student>, IStudentRepository
{
    public StudentRepository(Context db) : base(db)
    {
    }
}
