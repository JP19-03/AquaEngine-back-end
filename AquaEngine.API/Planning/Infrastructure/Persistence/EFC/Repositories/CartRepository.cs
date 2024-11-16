using AquaEngine.API.Planning.Domain.Model.Entities;
using AquaEngine.API.Planning.Domain.Repositories;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace AquaEngine.API.Planning.Infrastructure.Persistence.EFC.Repositories;

public class CartRepository(AppDbContext context) : BaseRepository<Cart>(context), ICartRepository;