using Faketun.Models;

namespace Faketun.Repositories;

public class SubjectRepository: GenericRepository<Subject>, ISubjectRepository
{
    public SubjectRepository(Context db) : base(db)
    {
    }
}
