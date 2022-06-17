using todoappstore.todoappstore.Domain.Commands;

namespace todo_app_store.Tests.CommandTests;

public class UpdateTodoCommandTests
{
	private readonly UpdateTodoCommand _invalidCommand = new UpdateTodoCommand(new Guid("8fcd6f63-8aa1-4eeb-97b4-5c91cb6ea4b0"), "", "");
	private readonly UpdateTodoCommand _validCommand = new UpdateTodoCommand(new Guid("8fcd6f63-8aa1-4eeb-97b4-5c91cb6ea4b0"), "paulo_ramos@live.com", "Novo Super Título");

	public UpdateTodoCommandTests()
	{
		_invalidCommand.Validate();
		_validCommand.Validate();
	}

	[Fact]
	public void DadoUmComandoDeUpdateInvalido()
	{
		Assert.False(_invalidCommand.Valid);
	}

	[Fact]
	public void DadoUmComandodeUpdateValido()
	{
		Assert.True(_validCommand.Valid);
	}

}