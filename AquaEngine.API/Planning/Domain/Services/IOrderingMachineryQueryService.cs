using AquaEngine.API.Planning.Domain.Model.Aggregates;
using AquaEngine.API.Planning.Domain.Model.Queries;

namespace AquaEngine.API.Planning.Domain.Services;

public interface IOrderingMachineryQueryService
{
    Task<IEnumerable<OrderingMachinery>> Handle(GetOrderingMachineryByUserIdQuery query);

    Task<OrderingMachinery?> Handle(GetOrderingMachineryByStatus query);

    Task<OrderingMachinery?> Handle(GetOrderingMachineryByIdQuery query);
}