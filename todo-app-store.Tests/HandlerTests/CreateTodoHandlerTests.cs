using System;
using System.Collections.Generic;
using System.Linq;
using todoappstore.todoappstore.Domain.Commands;
using todoappstore.todoappstore.Domain.Handlers;
using todoappstore.todoappstore.Tests.Repositories;

namespace todoappstore.todoappstore.Tests.HandlerTests
{

	public class CreateTodoHandlerTests
	{

		private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", DateTime.UtcNow, "");
		private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titilo da tarefa", DateTime.UtcNow, "paulo_ramos@live.com");
		private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());
		private GenericCommandResult _result = new GenericCommandResult();
		public CreateTodoHandlerTests()
		{
			_invalidCommand.Validate();
			_validCommand.Validate();
		}
		[Fact]
		public void DadoUmComandoInvalidoDeveInterromperAExecucao()
		{
			_result = (GenericCommandResult)_handler.Handle(_invalidCommand);
			Assert.False(_result.Success);

		}


		[Fact]
		public void DadoUmComandoValidoDeveConcluirAExecucao()
		{
			_result = (GenericCommandResult)_handler.Handle(_validCommand);
			Assert.True(_result.Success);

		}


	}


}