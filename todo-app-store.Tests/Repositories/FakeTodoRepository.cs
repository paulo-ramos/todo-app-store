using System;
using System.Collections.Generic;
using System.Linq;
using todoappstore.todoappstore.Domain.Entities;
using todoappstore.todoappstore.Domain.Repositories;

namespace todoappstore.todoappstore.Tests.Repositories
{

	public class FakeTodoRepository : ITodoRepository
	{

		public void Create(TodoItem todo)
		{

		}

		public IEnumerable<TodoItem> GetAll(string user)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TodoItem> GetAllDone(string user)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TodoItem> GetAllUndone(string user)
		{
			throw new NotImplementedException();
		}

		public TodoItem GetById(Guid id, string? user)
		{
			return new TodoItem("Titulo", DateTime.UtcNow.AddDays(-2), "paulo_ramos@live.com");
		}

		public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
		{
			throw new NotImplementedException();
		}

		public void Update(TodoItem todo)
		{

		}
	}


}