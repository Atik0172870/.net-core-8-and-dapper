using System.Diagnostics;
using CardAccess.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace CardAccess.Application.Common.Behaviors;
/// <summary>
/// Pipeline behavior for measuring the performance of request handling.
/// </summary>
/// <typeparam name="TRequest">Type of the request.</typeparam>
/// <typeparam name="TResponse">Type of the response.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="PerformanceBehavior{TRequest, TResponse}"/> class.
/// </remarks>
/// <param name="logger">The logger instance.</param>
/// <param name="user">The current user.</param>
/// <param name="identityService">The identity service.</param>
public class PerformanceBehavior<TRequest, TResponse>(
    ILogger<TRequest> logger,
    IUser user,
    IIdentityService identityService) : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly Stopwatch _timer = new();
    private readonly ILogger<TRequest> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    private readonly IUser _user = user ?? throw new ArgumentNullException(nameof(user));
    private readonly IIdentityService _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));

    /// <summary>
    /// Measures the performance of request handling.
    /// </summary>
    /// <param name="request">The request being processed.</param>
    /// <param name="next">The delegate representing the next step in the pipeline.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The response.</returns>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // Start timer
        _timer.Start();

        // Continue handling the request
        var response = await next();

        // Stop timer
        _timer.Stop();

        // Get elapsed time
        var elapsedMilliseconds = _timer.ElapsedMilliseconds;

        // If request took longer than 500 milliseconds, log a warning
        if (elapsedMilliseconds > 500)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _user.Id ?? Guid.Empty;
            var userName = string.Empty;

            if (userId == Guid.Empty)
            {
                userName = await _identityService.GetUserNameAsync(userId);
            }

            _logger.LogWarning("CardAccess Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@UserName} {@Request}",
                requestName, elapsedMilliseconds, userId, userName, request);
        }

        // Return the response
        return response;
    }
}

