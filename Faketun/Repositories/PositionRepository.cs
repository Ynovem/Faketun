using Faketun.Models;

namespace Faketun.Repositories;

public class PositionRepository: GenericRepository<Position>, IPositionRepository
{
    public PositionRepository(Context db) : base(db)
    {
    }
}
