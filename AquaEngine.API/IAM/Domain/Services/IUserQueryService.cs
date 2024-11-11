using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Aggregates;
using AquaEngine.API.IAM.Domain.Model.Queries;

namespace AquaEngine.API.IAM.Domain.Services;

/// <summary>
/// User query service 
/// </summary>
/// <remarks>
/// This service is responsible for handling user queries
/// </remarks>
public interface IUserQueryService
{
    /// <summary>
    /// Handle get user by id query 
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetUserByIdQuery"/> query containing user id
    /// </param>
    /// <returns>
    /// A task containing the <see cref="User"/> user if found, otherwise null
    /// </returns>
    Task<User?> Handle(GetUserByIdQuery query);
}