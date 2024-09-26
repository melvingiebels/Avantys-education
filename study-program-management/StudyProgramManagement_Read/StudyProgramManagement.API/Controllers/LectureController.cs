using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Query;
using StudyProgramManagement.Query.Queries.Class;
using StudyProgramManagement.Query.Queries.Lecture;

namespace StudyProgramManagement.Read.Controllers;

[ApiController]
[Route("[controller]")]
public class LectureController: ControllerBase
{
    private readonly IQueryFactory _queryFactory;

    public LectureController(IQueryFactory queryFactory)
    {
        _queryFactory = queryFactory;
    }

    [HttpGet]
    public List<LectureSchema> Get()
    {
        return _queryFactory.ResolveQuery<IGetAllLectures>()!.Excecute().ToList();
    }
    
    [HttpGet("{lectureId}")]
    public async Task<LectureSchema> GetById(Guid lectureId)
    {
        return await _queryFactory.ResolveQuery<IGetLectureById>()!.Excecute(lectureId);
    }
}