using todoappstore.todoappstore.Domain.Commands;

namespace todo_app_store.Tests.CommandTests;

public class CreateTodoCommandTests
{
	private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", DateTime.UtcNow, "");
	private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titilo da tarefa", DateTime.UtcNow, "paulo_ramos@live.com");

	public CreateTodoCommandTests()
	{
		_invalidCommand.Validate();
		_validCommand.Validate();
	}

	[Fact]
	public void DadoUmComandoInvalido()
	{
		Assert.False(_invalidCommand.Valid);
	}

	[Fact]
	public void DadoUmComandoValido()
	{
		Assert.True(_validCommand.Valid);
	}

}