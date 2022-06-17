
using Flunt.Notifications;
using todoappstore.todoappstore.Domain.Commands;
using todoappstore.todoappstore.Domain.Commands.Contracts;
using todoappstore.todoappstore.Domain.Entities;
using todoappstore.todoappstore.Domain.Handlers.Contracts;
using todoappstore.todoappstore.Domain.Repositories;

namespace todoappstore.todoappstore.Domain.Handlers
{

	public class TodoHandler :
		Notifiable,
		IHandler<CreateTodoCommand>,
		IHandler<UpdateTodoCommand>,
		IHandler<SetTodoAsDoneCommand>,
		IHandler<SetTodoAsUndoneCommand>
	{
		private readonly ITodoRepository _repositoy;
		public TodoHandler(ITodoRepository repository)
		{
			_repositoy = repository;
		}

		public ICommandResult Handle(CreateTodoCommand command)
		{
			//Fail Fast Validation
			command.Validate();
			if (command.Invalid)
			{
				return new GenericCommandResult(
					false,
					"Dados inválidos, favor verificar.",
					command.Notifications
				);
			}

			//Gera o novo TodoItem
			var todo = new TodoItem(
				command.Title,
				command.Date,
				command.User
			);

			//Salva no DB
			_repositoy.Create(todo);

			//Retorna o resultado
			return new GenericCommandResult(
					true,
					"Dados salvo com sucessor.",
					todo
			);
		}

		public ICommandResult Handle(UpdateTodoCommand command)
		{
			//Fail Fast Validation
			command.Validate();
			if (command.Invalid)
			{
				return new GenericCommandResult(
					false,
					"Dados inválidos, favor verificar.",
					command.Notifications
				);
			}

			//recupera o Item do DB (Reidratração)
			var todo = _repositoy.GetById(command.Id, command.User);

			//altera o título
			todo.SetNewTitle(command.Title);

			//Salva no DB
			_repositoy.Update(todo);

			//Retorna o resultado
			return new GenericCommandResult(
					true,
					"Dados atualizados com sucessor.",
					todo
			);
		}

		public ICommandResult Handle(SetTodoAsDoneCommand command)
		{
			//Fail Fast Validation
			command.Validate();
			if (command.Invalid)
			{
				return new GenericCommandResult(
					false,
					"Dados inválidos, favor verificar.",
					command.Notifications
				);
			}

			//recupera o Item do DB (Reidratração)
			var todo = _repositoy.GetById(command.Id, command.User);

			//altera o título
			todo.SetAsDone();

			//Salva no DB
			_repositoy.Update(todo);

			//Retorna o resultado
			return new GenericCommandResult(
					true,
					"Dados atualizados com sucessor.",
					todo
			);
		}

		public ICommandResult Handle(SetTodoAsUndoneCommand command)
		{
			//Fail Fast Validation
			command.Validate();
			if (command.Invalid)
			{
				return new GenericCommandResult(
					false,
					"Dados inválidos, favor verificar.",
					command.Notifications
				);
			}

			//recupera o Item do DB (Reidratração)
			var todo = _repositoy.GetById(command.Id, command.User);

			//altera o título
			todo.SetAsUndone();

			//Salva no DB
			_repositoy.Update(todo);

			//Retorna o resultado
			return new GenericCommandResult(
					true,
					"Dados atualizados com sucessor.",
					todo
			);
		}
	}
}
