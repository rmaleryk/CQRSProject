﻿using System;
using System.Threading.Tasks;
using CQRSProject.Commands.Extensibility;

namespace CQRSProject.Commands.CommandDispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var handler = (ICommandHandler<TCommand>)serviceProvider.GetService(typeof(ICommandHandler<TCommand>));

            if (handler == null)
            {
                throw new ArgumentException(nameof(TCommand));
            }

            await handler.ExecuteAsync(command);
        }
    }
}