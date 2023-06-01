namespace StudyProgramManagement.Commands.Commands;

public abstract class UpdateCommand<T>
{
    public T Model;

    protected UpdateCommand(T model)
    {
        Model = model;
    }
}