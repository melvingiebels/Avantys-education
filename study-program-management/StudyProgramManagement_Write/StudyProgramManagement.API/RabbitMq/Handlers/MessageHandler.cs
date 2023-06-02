namespace StudyProgramManagement.Commands.RabbitMq.Handlers;

public abstract class MessageHandler<T>
{
    public abstract void Handle(T? model);
}