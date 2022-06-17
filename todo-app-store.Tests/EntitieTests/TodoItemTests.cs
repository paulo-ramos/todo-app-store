using System;
using System.Collections.Generic;
using System.Linq;
using todoappstore.todoappstore.Domain.Entities;

namespace todoappstore.todoappstore.Tests.EntitieTests
{

	public class TodoItemTests
	{
		private readonly TodoItem _todoItem = new TodoItem("Titulo", DateTime.UtcNow, "paulo_ramos@live.com");

		[Fact]
		public void DadoUmNovoTodoItemOMesmoNaoPodeSerConcuido()
		{

			Assert.False(_todoItem.Done);

		}

		[Fact]
		public void DadoAlteracaoDoStatusDoneParaTrueRetornarOk()
		{

			_todoItem.SetAsDone();
			Assert.True(_todoItem.Done);

		}

		[Fact]
		public void DadoAlteracaoDoStatusDoneParaFalseRetornarKo()
		{

			_todoItem.SetAsUndone();
			Assert.False(_todoItem.Done);

		}

		[Fact]
		public void DadoAlteracaoDoTituloOMesmoDeveSerAlteradoNoModelo()
		{

			_todoItem.SetNewTitle("Novo Título");
			Assert.True(_todoItem.Title == "Novo Título");

		}

	}


}