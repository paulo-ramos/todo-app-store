using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using todoappstore.todoappstore.Domain.Entities;

namespace todoappstore.todoappstore.Infra.Context
{

	public class DataContext : DbContext
	{

		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		public DbSet<TodoItem> Todos => Set<TodoItem>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<TodoItem>().ToTable("Todo");
			modelBuilder.Entity<TodoItem>().Property(x => x.Id).IsRequired();
			modelBuilder.Entity<TodoItem>().Property(x => x.User).HasMaxLength(120).HasColumnType("varchar(120)");
			modelBuilder.Entity<TodoItem>().Property(x => x.Title).HasMaxLength(160).HasColumnType("varchar(120)");
			modelBuilder.Entity<TodoItem>().Property(x => x.Done).HasColumnType("bit");
			modelBuilder.Entity<TodoItem>().Property(x => x.Date);
			modelBuilder.Entity<TodoItem>().Property(x => x.CreatedAt);
			modelBuilder.Entity<TodoItem>().Property(x => x.UpdatedAt);
			modelBuilder.Entity<TodoItem>().HasIndex(b => b.User);

		}

	}

}