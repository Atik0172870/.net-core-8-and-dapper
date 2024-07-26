using CardAccess.Application.Common.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace CardAccess.Application.Common.Behaviors;

/// <summary>
/// Pipeline behavior for logging requests before processing.
/// </summary>
/// <typeparam name="TRequest">Type of the request.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="LoggingBehavior{TRequest}"/> class.
/// </remarks>
/// <param name="logger">The logger instance.</param>
/// <param name="user">The current user.</param>
/// <param name="identityService">The identity service.</param>
public class LoggingBehavior<TRequest>(
    ILogger<TRequest> logger,
    IUser user,
    IIdentityService identityService) : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    private readonly IUser _user = user ?? throw new ArgumentNullException(nameof(user));
    private readonly IIdentityService _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));

    /// <summary>
    /// Logs information about the request before processing.
    /// </summary>
    /// <param name="request">The request being processed.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        // Get the name of the request type
        var requestName = typeof(TRequest).Name;

        // Get user ID and username if available
        var userId = _user.Id ?? Guid.Empty;
        string? userName = string.Empty;

        // If user ID is available, get the username
        if (user.Id == Guid.Empty)
        {
            userName = await _identityService.GetUserNameAsync(userId);
        }

        // Log information about the request
        _logger.LogInformation("CardAccess Request: {Name} {@UserId} {@UserName} {@Request}",
            requestName, userId, userName, request);
    }
}

