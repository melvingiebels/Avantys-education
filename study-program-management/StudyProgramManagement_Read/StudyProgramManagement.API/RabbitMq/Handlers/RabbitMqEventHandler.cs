namespace StudyProgramManagement.Read.RabbitMq.Handlers;

public abstract class RabbitMqEventHandler<T>
{
    public abstract void Handle(T? model);
}