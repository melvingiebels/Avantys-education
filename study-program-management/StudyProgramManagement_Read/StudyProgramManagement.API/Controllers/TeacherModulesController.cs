using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Query;
using StudyProgramManagement.Query.Queries.Module;
using StudyProgramManagement.Query.Queries.TeacherModules;

namespace StudyProgramManagement.Read.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherModulesController: ControllerBase
{
    private readonly IQueryFactory _queryFactory;

    public TeacherModulesController(IQueryFactory queryFactory)
    {
        _queryFactory = queryFactory;
    }

    [HttpGet]
    public List<TeacherModulesSchema> Get()
    {
        return _queryFactory.ResolveQuery<IGetAllTeacherModules>()!.Excecute().ToList();
    }
    
    [HttpGet("{moduleId}")]
    public async Task<TeacherModulesSchema> GetById(Guid moduleId)
    {
        return await _queryFactory.ResolveQuery<IGetTeacherModuleById>()!.Excecute(moduleId);
    }
}