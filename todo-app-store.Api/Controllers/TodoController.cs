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

	}

}