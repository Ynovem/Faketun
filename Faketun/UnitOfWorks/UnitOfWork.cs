using Faketun.Models;
using Faketun.Repositories;

namespace Faketun.UnitOfWorks;

public class UnitOfWork: IDisposable
{
    private Context _db = new Context();

    private InstructorRepository? _instructorRepository;
    private SemesterRepository? _semesterRepository;
    private StudentRepository? _studentRepository;
    private SubjectRepository? _subjectRepository;

    public InstructorRepository? InstructorRepository
    {
        get { return _instructorRepository ??= new InstructorRepository(_db); }
    }

    public SemesterRepository? SemesterRepository
    {
        get { return _semesterRepository ??= new SemesterRepository(_db); }
    }

    public StudentRepository? StudentRepository
    {
        get { return _studentRepository ??= new StudentRepository(_db); }
    }

    public SubjectRepository? SubjectRepository
    {
        get { return _subjectRepository ??= new SubjectRepository(_db); }
    }

    public int Save()
    {
        return _db.SaveChanges();
    }






    private bool _disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
    }
}
