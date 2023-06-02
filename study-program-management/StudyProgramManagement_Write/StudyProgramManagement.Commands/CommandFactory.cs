using Microsoft.Extensions.DependencyInjection;

namespace StudyProgramManagement.Commands;

public class CommandFactory : ICommandsFactory
{
    private readonly IServiceProvider _serviceProvider;

    public CommandFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void ExecuteQuery<T>(T command)
        where T : ICommand
    {
        var commandHandlers = _serviceProvider.GetServices<ICommandHandler<T>>();

        if (commandHandlers != null && commandHandlers.Any())
            foreach (var commandHandler in commandHandlers)
            {
                commandHandler.Execute(command);
                commandHandler.Dispose();
            }
        else
            throw new ArgumentException("Unknown command \"" + typeof(T).FullName + "\"");
    }
}