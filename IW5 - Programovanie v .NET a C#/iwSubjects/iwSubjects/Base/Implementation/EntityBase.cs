using System;
using iwSubjects.Base.Interface;

namespace iwSubjects.Base.Implementation
{
    public abstract class EntityBase : EntityInterface
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}