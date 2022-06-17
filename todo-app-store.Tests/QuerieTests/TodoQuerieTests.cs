using System;
using System.Collections.Generic;
using System.Linq;
using todoappstore.todoappstore.Domain.Entities;
using todoappstore.todoappstore.Domain.Queries;

namespace todoappstore.todoappstore.Tests.QuerieTests
{

	public class TodoQuerieTests
	{
		private List<TodoItem> _items;

		public TodoQuerieTests()
		{
			_items = new List<TodoItem>();
			_items.Add(new TodoItem("Tarefa 1", DateTime.UtcNow, "usuario1"));
			_items.Add(new TodoItem("Tarefa 2", DateTime.UtcNow, "paulo_ramos@live.com"));
			_items.Add(new TodoItem("Tarefa 3", DateTime.UtcNow, "paulo_ramos@live.com"));
			_items.Add(new TodoItem("Tarefa 4", DateTime.UtcNow, "paulo_ramos@live.com"));
			_items.Add(new TodoItem("Tarefa 5", DateTime.UtcNow, "usuario5"));
			_items.Add(new TodoItem("Tarefa 6", DateTime.UtcNow, "usuario6"));

		}

		[Fact]
		public void DataUmaConsultaDeveRetornarApenasDeUmUsuarioEspecifico()
		{
			var result = _items.AsQueryable().Where(TodoQueries.GetAll("paulo_ramos@live.com"));
			Assert.True(result.Count() == 3);

		}

		[Fact]
		public void DataUmaConsultaNaoDeveRetornarDeOutroUsuarioEspecifico()
		{
			var result = _items.AsQueryable().Where(TodoQueries.GetAll("usuario1"));
			Assert.False(result.Count() == 3);

		}

		[Fact]
		public void DataUmaConsultaNaoDeveRetornarDeUmUsuarioEspecificoSomenteDone()
		{
			var result = _items.AsQueryable().Where(TodoQueries.GetAllDone("paulo_ramos@live.com"));
			Assert.True(result.Count() == 0);

		}

		[Fact]
		public void DataUmaConsultaNaoDeveRetornarDeUmUsuarioEspecificoSomenteUndone()
		{
			var result = _items.AsQueryable().Where(TodoQueries.GetAllUndone("paulo_ramos@live.com"));
			Assert.True(result.Count() == 3);

		}

		[Fact]
		public void DataUmaConsultaNaoDeveRetornarDeUmUsuarioEspecificoSomenteUndoneEmUmDeterminadoPeriodo()
		{
			var result = _items.AsQueryable().Where(TodoQueries.GetByPeriod("paulo_ramos@live.com", DateTime.UtcNow, false));
			Assert.True(result.Count() == 3);

		}

		[Fact]
		public void DataUmaConsultaNaoDeveRetornarDeUmUsuarioEspecificoSomenteDoneEmUmDeterminadoPeriodo()
		{
			var result = _items.AsQueryable().Where(TodoQueries.GetByPeriod("paulo_ramos@live.com", DateTime.UtcNow, true));
			Assert.True(result.Count() == 0);

		}

		[Fact]
		public void DataUmaConsultaNaoDeveRetornarDeUmUsuarioEspecificoSomenteDoneEmUmPeriodoInvalido()
		{
			var result = _items.AsQueryable().Where(TodoQueries.GetByPeriod("paulo_ramos@live.com", DateTime.UtcNow.AddDays(-8), false));
			Assert.True(result.Count() == 0);

		}

	}


}