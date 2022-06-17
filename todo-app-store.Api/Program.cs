using Microsoft.EntityFrameworkCore;
using todoappstore.todoappstore.Domain.Handlers;
using todoappstore.todoappstore.Domain.Repositories;
using todoappstore.todoappstore.Infra.Context;
using todoappstore.todoappstore.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// builder.Services.AddTransient --resolve a dependencia criando sob demanda, não utiliza da memoria
// builder.Services.AddScoped -- uma instancia por requisição, fica na mmoria para as proximas requisições.
// builder.Services.AddSingleton --uma instancia por aplicação, uma única vez.

builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
builder.Services.AddTransient<ITodoRepository, TodoRepository>();
builder.Services.AddTransient<TodoHandler, TodoHandler>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors(x => x
	.AllowAnyOrigin()
	.AllowAnyMethod()
	.AllowAnyHeader()
);

app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();
