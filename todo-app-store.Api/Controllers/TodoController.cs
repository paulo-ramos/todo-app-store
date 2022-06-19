using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using todoappstore.todoappstore.Domain.Commands;
using todoappstore.todoappstore.Domain.Entities;
using todoappstore.todoappstore.Domain.Handlers;
using todoappstore.todoappstore.Domain.Repositories;

namespace todoappstore.todoappstore.Api.Controllers
{

	[ApiController]
	[Route("v1/todos")]
	public class TodoController : ControllerBase
	{
		[Route("")]
		[HttpGet]
		public IEnumerable<TodoItem> GetAll(
			[FromServices] ITodoRepository repository
		)
		{
			return repository.GetAll("paulo_ramos@live.com");
		}

		[Route("done")]
		[HttpGet]
		public IEnumerable<TodoItem> GetAllDone(
			[FromServices] ITodoRepository repository
		)
		{
			return repository.GetAllDone("paulo_ramos@live.com");
		}

		[Route("undone")]
		[HttpGet]
		public IEnumerable<TodoItem> GetAllUndone(
			[FromServices] ITodoRepository repository
		)
		{
			return repository.GetAllUndone("paulo_ramos@live.com");
		}

		[Route("done/today")]
		[HttpGet]
		public IEnumerable<TodoItem> GetAllDoneForToday(
			[FromServices] ITodoRepository repository
		)
		{
			return repository.GetByPeriod("paulo_ramos@live.com", DateTime.UtcNow.Date, true);
		}

		[Route("undone/today")]
		[HttpGet]
		public IEnumerable<TodoItem> GetAllUndoneForToday(
			[FromServices] ITodoRepository repository
		)
		{
			return repository.GetByPeriod("paulo_ramos@live.com", DateTime.UtcNow.Date, false);
		}

		[Route("done/tomorow")]
		[HttpGet]
		public IEnumerable<TodoItem> GetAllDoneForTomorow(
			[FromServices] ITodoRepository repository
		)
		{
			return repository.GetByPeriod("paulo_ramos@live.com", DateTime.UtcNow.Date.AddDays(1), true);
		}

		[Route("undone/tomorow")]
		[HttpGet]
		public IEnumerable<TodoItem> GetAllUndoneForTomorow(
			[FromServices] ITodoRepository repository
		)
		{
			return repository.GetByPeriod("paulo_ramos@live.com", DateTime.UtcNow.Date.AddDays(1), false);
		}

		[Route("")]
		[HttpPost]
		public GenericCommandResult Create(
			[FromBody] CreateTodoCommand command,
			[FromServices] TodoHandler handler
		)
		{
			command.User = "paulo_ramos@live.com";
			return (GenericCommandResult)handler.Handle(command);
		}

		[Route("")]
		[HttpPut]
		public GenericCommandResult Update(
			[FromBody] UpdateTodoCommand command,
			[FromServices] TodoHandler handler
		)
		{
			command.User = "paulo_ramos@live.com";
			return (GenericCommandResult)handler.Handle(command);
		}

		[Route("mark-as-done")]
		[HttpPut]
		public GenericCommandResult SetAsDone(
			[FromBody] SetTodoAsDoneCommand command,
			[FromServices] TodoHandler handler
		)
		{
			command.User = "paulo_ramos@live.com";
			return (GenericCommandResult)handler.Handle(command);
		}

		[Route("mark-as-undone")]
		[HttpPut]
		public GenericCommandResult SetAsUndone(
			[FromBody] SetTodoAsUndoneCommand command,
			[FromServices] TodoHandler handler
		)
		{
			command.User = "paulo_ramos@live.com";
			return (GenericCommandResult)handler.Handle(command);
		}

	}

}