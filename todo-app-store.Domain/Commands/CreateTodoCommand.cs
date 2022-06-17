using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;
using Flunt.Validations;
using todoappstore.todoappstore.Domain.Commands;
using todoappstore.todoappstore.Domain.Commands.Contracts;

namespace todoappstore.todoappstore.Domain.Commands
{

	public class CreateTodoCommand : Notifiable, ICommand
	{

		public string? Title { get; set; }
		public DateTime Date { get; set; }
		public string? User { get; set; }

		public CreateTodoCommand()
		{

		}

		public CreateTodoCommand(string title, DateTime date, string user)
		{
			Title = title;
			Date = date;
			User = user;
		}

		public void Validate()
		{
			AddNotifications(new Contract()
				.Requires()
				.HasMinLen(Title, 3, "Title", "A tarefa deve possuir mais de três caracteres.")
				.HasMinLen(User, 6, "User", "Usuário inválido, deve possuir mais de 6 caracteres.")
			);
		}
	}


}