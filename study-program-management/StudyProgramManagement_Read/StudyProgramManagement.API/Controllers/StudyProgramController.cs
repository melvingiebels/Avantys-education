using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Query;
using StudyProgramManagement.Query.Queries.Module;
using StudyProgramManagement.Query.Queries.StudyProgram;

namespace StudyProgramManagement.Read.Controllers;

[ApiController]
[Route("[controller]")]
public class StudyProgramController: ControllerBase
{
    private readonly IQueryFactory _queryFactory;

    public StudyProgramController(IQueryFactory queryFactory)
    {
        _queryFactory = queryFactory;
    }

    [HttpGet]
    public List<StudyProgramSchema> Get()
    {
        return _queryFactory.ResolveQuery<IGetAllStudyPrograms>()!.Excecute().ToList();
    }
    
    [HttpGet("{studyProgramId}")]
    public async Task<StudyProgramSchema> GetById(Guid studyProgramId)
    {
        return await _queryFactory.ResolveQuery<IGetStudyProgramById>()!.Excecute(studyProgramId);
    }
}