using MongoDB.Driver;
using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Infrastructure.MongoDb.Collection;

public class StudentCollection: MongoCollection<StudentSchema>
 {
     public StudentCollection(MongoDbClient mongoDb) : base(mongoDb)
     {
     }
 }