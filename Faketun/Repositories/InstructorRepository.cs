using Faketun.Models;

namespace Faketun.Repositories;

public class InstructorRepository: GenericRepository<Instructor>, IInstructorRepository
{
    public InstructorRepository(Context db) : base(db)
    {
    }
}
