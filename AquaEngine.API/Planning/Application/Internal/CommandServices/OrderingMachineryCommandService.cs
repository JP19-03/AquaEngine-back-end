using AquaEngine.API.Planning.Domain.Model.Aggregates;
using AquaEngine.API.Planning.Domain.Model.Commands;
using AquaEngine.API.Planning.Domain.Repositories;
using AquaEngine.API.Planning.Domain.Services;
using AquaEngine.API.Shared.Domain.Repositories;

namespace AquaEngine.API.Planning.Application.Internal.CommandServices;

public class OrderingMachineryCommandService (IOrderingMachineryRepository orderingMachineryRepository, IUnitOfWork unitOfWork)
: IOrderingMachineryCommandService
{
    public async Task<OrderingMachinery?> Handle(CreateOrderingMachineryCommand command)
    {
        var orderingMachinery = new OrderingMachinery(command);
        try
        {
            await orderingMachineryRepository.AddAsync(orderingMachinery);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return orderingMachinery;
    }
    public async Task<OrderingMachinery> Handle(UpdateOrderingStatusCommand command)
    {
        var orderingMachinery = await orderingMachineryRepository.FindByIdAsync((int)command.Id);
        
        if (orderingMachinery == null)
            throw new ArgumentException("Ordering not found");

        try
        {
            orderingMachinery.UpdateStatus(command);
            orderingMachineryRepository.Update(orderingMachinery);
            await unitOfWork.CompleteAsync();

            return orderingMachinery;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}