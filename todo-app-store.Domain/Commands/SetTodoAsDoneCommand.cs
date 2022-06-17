using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;
using Flunt.Validations;
using todoappstore.todoappstore.Domain.Commands.Contracts;

namespace todoappstore.todoappstore.Domain.Commands
{

	public class SetTodoAsDoneCommand : Notifiable, ICommand
	{
		public SetTodoAsDoneCommand()
		{

		}
		public SetTodoAsDoneCommand(Guid id, string user)
		{
			Id = id;
			User = user;
		}

		public Guid Id { get; set; }
		public string? User { get; set; }

		public void Validate()
		{
			AddNotifications(new Contract()
				.Requires()
				.HasMinLen(User, 6, "User", "Usuário inválido, deve possuir ao menos 6 caracteres.")
			);
		}
	}


}