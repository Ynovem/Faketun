using Faketun.Models;

namespace Faketun.Repositories;

public interface IInstructorSubjectRepository
{
    public IQueryable<InstructorSubject> GetAll();
    public Task<bool> Assign(int instructionId, int subjectId);
    public Task<bool> Unassign(int instructionId, int subjectId);
}
