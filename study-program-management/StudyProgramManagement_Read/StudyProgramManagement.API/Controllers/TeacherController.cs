using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Query;
using StudyProgramManagement.Query.Queries.Module;
using StudyProgramManagement.Query.Queries.Teacher;

namespace StudyProgramManagement.Read.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherController: ControllerBase
{
    private readonly IQueryFactory _queryFactory;

    public TeacherController(IQueryFactory queryFactory)
    {
        _queryFactory = queryFactory;
    }

    [HttpGet]
    public List<TeacherSchema> Get()
    {
        return _queryFactory.ResolveQuery<IGetAllTeachers>()!.Excecute().ToList();
    }
    
    [HttpGet("{teacherId}")]
    public async Task<TeacherSchema> GetById(Guid teacherId)
    {
        return await _queryFactory.ResolveQuery<IGetTeacherById>()!.Excecute(teacherId);
    }
}