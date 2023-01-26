using Faketun.Models;

namespace Faketun.Repositories;

public class CourseRepository: GenericRepository<Course>, ICourseRepository
{
    public CourseRepository(Context db) : base(db)
    {
    }
}
