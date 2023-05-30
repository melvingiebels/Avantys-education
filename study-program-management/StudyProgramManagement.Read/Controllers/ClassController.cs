using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Commands;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Infrastructure.Handlers.QueryHandler.Class;
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

    public List<ClassSchema> Get()
    {
        return _queryFactory.ResolveQuery<IGetAllClasses>()!.Excecute().ToList();
    }
}