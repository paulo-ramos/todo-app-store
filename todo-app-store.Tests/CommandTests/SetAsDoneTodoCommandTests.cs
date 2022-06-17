using todoappstore.todoappstore.Domain.Commands;

namespace todo_app_store.Tests.CommandTests;

public class SetAsDoneTodoCommandTests
{
	private readonly SetTodoAsDoneCommand _invalidCommand = new SetTodoAsDoneCommand(new Guid("8fcd6f63-8aa1-4eeb-97b4-5c91cb6ea4b0"), "");
	private readonly SetTodoAsDoneCommand _validCommand = new SetTodoAsDoneCommand(new Guid("8fcd6f63-8aa1-4eeb-97b4-5c91cb6ea4b0"), "paulo_ramos@live.com");

	public SetAsDoneTodoCommandTests()
	{
		_invalidCommand.Validate();
		_validCommand.Validate();
	}

	[Fact]
	public void DadoUmComandoSetAsDoneInvalido()
	{
		Assert.False(_invalidCommand.Valid);
	}

	[Fact]
	public void DadoUmComandoSetAsDoneValido()
	{
		Assert.True(_validCommand.Valid);
	}

}