using Faketun.Models;

namespace Faketun.Repositories;

public class SemesterRepository: GenericRepository<Semester>, ISemesterRepository
{
    public SemesterRepository(Context db): base(db)
    {
    }
}
