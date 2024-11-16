using AquaEngine.API.Planning.Domain.Model.Commands;
using AquaEngine.API.Planning.Domain.Model.Entities;

namespace AquaEngine.API.Planning.Domain.Services;

public interface ICartCommandService
{
    /// <summary>
    /// Handles the create cart command
    /// </summary>
    /// <param name="command">
    /// The <see cref="CreateCartCommand"/> command to handle.
    /// </param>
    /// <returns>
    /// The created <see cref="Cart"/> entity.
    /// </returns>
    public Task<Cart?> Handle(CreateCartCommand command);
}