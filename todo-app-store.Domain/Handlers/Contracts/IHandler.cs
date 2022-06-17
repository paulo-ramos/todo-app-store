using System;
using System.Collections.Generic;
using todoappstore.todoappstore.Domain.Commands.Contracts;

namespace todoappstore.todoappstore.Domain.Handlers.Contracts
{

	public interface IHandler<T> where T : ICommand
	{
		ICommandResult Handle(T command);
	}

}