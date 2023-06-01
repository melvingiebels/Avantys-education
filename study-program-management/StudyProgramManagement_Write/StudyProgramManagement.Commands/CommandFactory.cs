﻿using System;
using System.Linq;

namespace StudyProgramManagement.Commands;

public class CommandFactory : ICommandsFactory
{
    private readonly Func<Type, object[]> _resolveCallback;

    public CommandFactory(Func<Type, object[]> resolveCallback)
    {
        _resolveCallback = resolveCallback;
    }

    public void ExecuteQuery<T>(T command)
        where T : ICommand
    {
        // Initialize context
        var commandHandlers =
            _resolveCallback(typeof(ICommandHandler<T>))
                .OfType<ICommandHandler<T>>();

        if (commandHandlers != null && commandHandlers.Any())
            foreach (var commandHandler in commandHandlers)
            {
                // Execute command
                commandHandler.Execute(command);

                // Dispose context
                commandHandler.Dispose();
            }
        else
            throw new ArgumentException("Unknown command \"" + typeof(T).FullName + "\"");
    }
}