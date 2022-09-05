using DM.Shared.Core.Aggregates;
using DM.Shared.Core.Entities;
using EntityFrameworkCore.CommonTools;

namespace DM.Modules.Tasks.Application.Specifications
{
    internal class ActiveSpecification<TAggregate> : Specification<TAggregate>
        where TAggregate : AggregateRoot, IEntity, IDeletableAggreagateRoot
    {
        public ActiveSpecification() : base(ag => !ag.IsDeleted) { }
    }
}
