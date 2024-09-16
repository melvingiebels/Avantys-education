using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Query;
using StudyProgramManagement.Query.Queries.Module;

namespace StudyProgramManagement.Read.Controllers;

[ApiController]
[Route("[controller]")]
public class ModuleController: ControllerBase
{
    private readonly IQueryFactory _queryFactory;

    public ModuleController(IQueryFactory queryFactory)
    {
        _queryFactory = queryFactory;
    }

    [HttpGet]
    public List<ModuleSchema> Get()
    {
        return _queryFactory.ResolveQuery<IGetAllModules>()!.Excecute().ToList();
    }
    
    [HttpGet("{moduleId}")]
    public async Task<ModuleSchema> GetById(Guid moduleId)
    {
        return await _queryFactory.ResolveQuery<IGetModuleById>()!.Excecute(moduleId);
    }
}