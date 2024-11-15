using AquaEngine.API.Planning.Domain.Model.Aggregates;
using AquaEngine.API.Planning.Domain.Model.Queries;
using AquaEngine.API.Planning.Domain.Repositories;
using AquaEngine.API.Planning.Domain.Services;

namespace AquaEngine.API.Planning.Application.Internal.QueryServices;

public class OrderingMachineryQueryService(IOrderingMachineryRepository orderingMachineryRepository) : IOrderingMachineryQueryService
{
    public async Task<OrderingMachinery?> Handle(GetOrderingMachineryByIdQuery query)
    {
        return await orderingMachineryRepository.FindByIdAsync(query.Id);
    }

    public async Task<OrderingMachinery?> Handle(GetOrderingMachineryByStatus query)
    {
        return await orderingMachineryRepository.FindByStatusAsync(query.Status);
    }
    
    public async Task<IEnumerable<OrderingMachinery>> Handle(GetAllOrderingMachineryQuery query)
    {
        return await orderingMachineryRepository.ListAsync();
    }

    public async Task<OrderingMachinery?> Handle(GetOrderingMachineryByStockCheckResult query)
    {
        return await orderingMachineryRepository.FindByStockCheckResultAsync(query.StockAspect);
    }
}