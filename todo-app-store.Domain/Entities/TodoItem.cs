using System;
using System.Collections.Generic;
using System.Linq;

namespace todoappstore.todoappstore.Domain.Entities
{

	public class TodoItem : Entity
	{
		public TodoItem()
		{
		}
		public TodoItem(string? title, DateTime date, string? user)
		{
			Title = title;
			Done = false;
			Date = date;
			User = user;
		}

		public void SetAsDone()
		{
			Done = true;
			SetAsUpdatedAt();
		}

		public void SetAsUndone()
		{
			Done = false;
			SetAsUpdatedAt();
		}

		public void SetNewTitle(string? newTitle)
		{
			Title = newTitle;
			SetAsUpdatedAt();
		}

		public string? Title { get; private set; }
		public bool Done { get; private set; }
		public DateTime Date { get; private set; }
		public string? User { get; private set; }
	}

}