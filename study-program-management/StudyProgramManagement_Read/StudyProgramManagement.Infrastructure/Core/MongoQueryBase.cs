using StudyProgramManagement.Query;

namespace StudyProgramManagement.Infrastructure.Core;

public abstract class MongoQueryBase<TCollection> : IQuery
{
    protected readonly TCollection Collection;

    protected MongoQueryBase(TCollection collection)
    {
        Collection = collection;
    }
}