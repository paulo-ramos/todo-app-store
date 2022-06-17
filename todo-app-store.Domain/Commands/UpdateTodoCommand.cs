using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;
using Flunt.Validations;
using todoappstore.todoappstore.Domain.Commands.Contracts;

namespace todoappstore.todoappstore.Domain.Commands
{

	public class UpdateTodoCommand : Notifiable, ICommand
	{
		public UpdateTodoCommand()
		{
		}
		public UpdateTodoCommand(Guid id, string user, string title)
		{
			Id = id;
			User = user;
			Title = title;
		}

		public Guid Id { get; set; }
		public string? User { get; set; }
		public string? Title { get; set; }

		public void Validate()
		{
			AddNotifications(new Contract()
				.Requires()
				.HasMinLen(Title, 3, "Title", "A tarefa deve possuir mais de três caracteres.")
				.HasMinLen(User, 6, "User", "Usuário inválido, deve possuir mais de 6 caracteres."));
		}
	}


}