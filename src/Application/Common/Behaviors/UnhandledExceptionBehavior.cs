using Microsoft.Extensions.Logging;

namespace CardAccess.Application.Common.Behaviors;

/// <summary>
/// Pipeline behavior for handling unhandled exceptions in request processing.
/// </summary>
/// <typeparam name="TRequest">Type of the request.</typeparam>
/// <typeparam name="TResponse">Type of the response.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="UnhandledExceptionBehavior{TRequest, TResponse}"/> class.
/// </remarks>
/// <param name="logger">The logger instance.</param>
public class UnhandledExceptionBehavior<TRequest, TResponse>(
    ILogger<TRequest> logger) : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly ILogger<TRequest> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    /// <summary>
    /// Handles unhandled exceptions during request processing.
    /// </summary>
    /// <param name="request">The request being processed.</param>
    /// <param name="next">The delegate representing the next step in the pipeline.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The response.</returns>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            // Continue handling the request
            return await next();
        }
        catch (Exception ex)
        {
            // Log the exception
            var requestName = typeof(TRequest).Name;
            _logger.LogError(ex, "CardAccess Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);

            // Re-throw the exception
            throw;
        }
    }
}

