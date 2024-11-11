using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Aggregates;
using AquaEngine.API.IAM.Domain.Model.Queries;
using AquaEngine.API.IAM.Domain.Repositories;
using AquaEngine.API.IAM.Domain.Services;

namespace AquaEngine.API.IAM.Application.Internal.CommandServices;

/// <summary>
/// User query service. 
/// </summary>
/// <param name="userRepository">
/// The <see cref="IUserRepository"/> instance.
/// </param>
public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    // <inheritdoc/>
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.Id);
    }
}