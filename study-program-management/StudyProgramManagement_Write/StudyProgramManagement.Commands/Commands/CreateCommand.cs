namespace StudyProgramManagement.Commands.Commands;

public abstract class CreateCommand<T>
{
    public T Model;

    protected CreateCommand(T model)
    {
        Model = model;
    }
}