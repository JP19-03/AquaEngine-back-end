using AquaEngine.API.Planning.Domain.Model.Aggregates;
using AquaEngine.API.Planning.Domain.Model.Commands;

namespace AquaEngine.API.Planning.Domain.Services;

public interface IOrderingMachineryCommandService
{
    Task<OrderingMachinery?> Handle(CreateOrderingMachineryCommand command);
    Task<OrderingMachinery> Handle(UpdateOrderingStatusCommand command);
}