using DM.Shared.Core.Aggregates;
using DM.Shared.Core.Entities;
using EntityFrameworkCore.CommonTools;

namespace DM.Modules.Tasks.Application.Specifications
{
    internal class ByIdSpecification<TAggregate> : Specification<TAggregate>
        where TAggregate : AggregateRoot, IEntity
    {
        public ByIdSpecification(Guid id) : base(ag => ag.Id == id) { }
    }
}
