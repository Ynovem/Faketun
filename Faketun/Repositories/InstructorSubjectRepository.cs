using Faketun.Models;
using Microsoft.EntityFrameworkCore;

namespace Faketun.Repositories;

public class InstructorSubjectRepository : IInstructorSubjectRepository
{
    protected readonly Context _db;

    public InstructorSubjectRepository(Context db)
    {
        _db = db;
    }

    public IQueryable<InstructorSubject> GetAll()
    {
        return _db.Set<InstructorSubject>().AsNoTracking();
    }

    public async Task<bool> Assign(int instructionId, int subjectId)
    {
        await _db.Set<InstructorSubject>().AddAsync(new InstructorSubject
        {
            InstructorId = instructionId,
            SubjectId = subjectId,
        });
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<bool> Unassign(int instructionId, int subjectId)
    {
        _db.Set<InstructorSubject>().Remove(new InstructorSubject
        {
            InstructorId = instructionId,
            SubjectId = subjectId,
        });
        return await _db.SaveChangesAsync() > 0;
    }
}
