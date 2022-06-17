using System;
using System.Collections.Generic;
using System.Linq;
using todoappstore.todoappstore.Domain.Commands;
using todoappstore.todoappstore.Domain.Handlers;
using todoappstore.todoappstore.Tests.Repositories;

namespace todoappstore.todoappstore.Tests.HandlerTests
{

	public class SetAsDoneTodoHandlerTests
	{

		private readonly SetTodoAsDoneCommand _invalidCommand = new SetTodoAsDoneCommand(new Guid("8fcd6f63-8aa1-4eeb-97b4-5c91cb6ea4b0"), "");
		private readonly SetTodoAsDoneCommand _validCommand = new SetTodoAsDoneCommand(new Guid("8fcd6f63-8aa1-4eeb-97b4-5c91cb6ea4b0"), "paulo_ramos@live.com");
		private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());
		private GenericCommandResult _result = new GenericCommandResult();
		public SetAsDoneTodoHandlerTests()
		{
			_invalidCommand.Validate();
			_validCommand.Validate();
		}
		[Fact]
		public void DadoUmComandoInvalidoDeveInterromperAAtualizacaoAsDone()
		{
			_result = (GenericCommandResult)_handler.Handle(_invalidCommand);
			Assert.False(_result.Success);

		}


		[Fact]
		public void DadoUmComandoValidoDeveConcluirAAtualizacaoAsDone()
		{
			_result = (GenericCommandResult)_handler.Handle(_validCommand);
			Assert.True(_result.Success);

		}


	}


}