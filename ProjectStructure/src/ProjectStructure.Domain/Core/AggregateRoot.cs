using System;

namespace ProjectStructure.Domain.Core
{
    public class AggregateRoot : Entity
    {
        protected AggregateRoot() { }

        public AggregateRoot(Guid? id)
            : base(id) { }
    }
}
