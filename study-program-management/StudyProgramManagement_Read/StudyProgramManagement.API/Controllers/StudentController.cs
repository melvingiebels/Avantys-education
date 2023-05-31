using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Query;
using StudyProgramManagement.Query.Queries.Module;
using StudyProgramManagement.Query.Queries.Student;

namespace StudyProgramManagement.Read.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController: ControllerBase
{
    private readonly IQueryFactory _queryFactory;

    public StudentController(IQueryFactory queryFactory)
    {
        _queryFactory = queryFactory;
    }

    [HttpGet]
    public List<StudentSchema> Get()
    {
        return _queryFactory.ResolveQuery<IGetAllStudents>()!.Excecute().ToList();
    }
    
    [HttpGet("{studentId}")]
    public async Task<StudentSchema> GetById(Guid studentId)
    {
        return await _queryFactory.ResolveQuery<IGetStudentById>()!.Excecute(studentId);
    }
}