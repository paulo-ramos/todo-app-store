using System;
using System.Collections.Generic;
using System.Linq;

namespace todoappstore.todoappstore.Domain.Entities
{

	public abstract class Entity : IEquatable<Entity>
	{
		public Guid Id { get; private set; }
		public DateTime CreatedAt { get; private set; }
		public DateTime UpdatedAt { get; private set; }

		protected Entity()
		{
			Id = Guid.NewGuid();
			CreatedAt = DateTime.UtcNow;
			UpdatedAt = DateTime.UtcNow;
		}

		public void SetAsUpdatedAt()
		{
			UpdatedAt = DateTime.UtcNow;
		}

		public bool Equals(Entity? other)
		{
			return other != null && Id == other.Id;
		}
	}


}