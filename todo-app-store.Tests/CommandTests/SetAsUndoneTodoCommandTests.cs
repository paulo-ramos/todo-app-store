using todoappstore.todoappstore.Domain.Commands;

namespace todo_app_store.Tests.CommandTests;

public class SetAsUndoneTodoCommandTests
{
	private readonly SetTodoAsUndoneCommand _invalidCommand = new SetTodoAsUndoneCommand(new Guid("8fcd6f63-8aa1-4eeb-97b4-5c91cb6ea4b0"), "");
	private readonly SetTodoAsUndoneCommand _validCommand = new SetTodoAsUndoneCommand(new Guid("8fcd6f63-8aa1-4eeb-97b4-5c91cb6ea4b0"), "paulo_ramos@live.com");

	public SetAsUndoneTodoCommandTests()
	{
		_invalidCommand.Validate();
		_validCommand.Validate();
	}

	[Fact]
	public void DadoUmComandoSetAsUndoneInvalido()
	{
		Assert.False(_invalidCommand.Valid);
	}

	[Fact]
	public void DadoUmComandoSetAsUndoneValido()
	{
		Assert.True(_validCommand.Valid);
	}

}