using Microsoft.AspNetCore.Mvc;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Query;

using StudyProgramManagement.Query.Queries.LecturesSchedule;

namespace StudyProgramManagement.Read.Controllers;

[ApiController]
[Route("[controller]")]
public class LectureScheduleController: ControllerBase
{
    private readonly IQueryFactory _queryFactory;

    public LectureScheduleController(IQueryFactory queryFactory)
    {
        _queryFactory = queryFactory;
    }
    [HttpGet]
    public List<LecturesScheduleSchema> Get()
    {
        return _queryFactory.ResolveQuery<IGetAllLectureSchedules>()!.Excecute().ToList();
    }
    
    [HttpGet("{lectureScheduleId}")]
    public async Task<LecturesScheduleSchema> GetById(Guid classId)
    {
        return await _queryFactory.ResolveQuery<IGetLectureScheduleById>()!.Excecute(classId);
    }
}