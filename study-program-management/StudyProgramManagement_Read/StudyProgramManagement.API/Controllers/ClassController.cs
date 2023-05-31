using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Query;
using StudyProgramManagement.Query.Queries.Class;

namespace StudyProgramManagement.Read.Controllers;

[ApiController]
[Route("[controller]")]
public class ClassController : ControllerBase
{
    private readonly IQueryFactory _queryFactory;

    public ClassController(IQueryFactory queryFactory)
    {
        _queryFactory = queryFactory;
    }
    [HttpGet]
    public List<ClassSchema> Get()
    {
        return _queryFactory.ResolveQuery<IGetAllClasses>()!.Excecute().ToList();
    }
    
    [HttpGet("{classId}")]
    public async Task<ClassSchema> GetById(Guid classId)
    {
        return await _queryFactory.ResolveQuery<IGetClassById>()!.Excecute(classId);
    }
}