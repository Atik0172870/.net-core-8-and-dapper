using ValidationException = CardAccess.Application.Common.Exceptions.ValidationException;

namespace CardAccess.Application.Common.Behaviors;

/// <summary>
/// Pipeline behavior for request validation using FluentValidation.
/// </summary>
/// <typeparam name="TRequest">Type of the request.</typeparam>
/// <typeparam name="TResponse">Type of the response.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="ValidationBehavior{TRequest, TResponse}"/> class.
/// </remarks>
/// <param name="validators">The validators for the request.</param>
public class ValidationBehavior<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators ?? throw new ArgumentNullException(nameof(validators));

    /// <summary>
    /// Handles request validation using FluentValidation.
    /// </summary>
    /// <param name="request">The request being processed.</param>
    /// <param name="next">The delegate representing the next step in the pipeline.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The response.</returns>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // Check if there are any validators
        if (_validators.Any())
        {
            // Create a validation context for the request
            var context = new ValidationContext<TRequest>(request);

            // Execute all validators asynchronously
            var validationResults = await Task.WhenAll(
                _validators.Select(v =>
                    v.ValidateAsync(context, cancellationToken)));

            // Aggregate validation failures
            var failures = validationResults
                .Where(r => r.Errors.Count != 0)
                .SelectMany(r => r.Errors)
                .ToList();

            // If there are validation failures, throw a ValidationException
            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }
        }

        // Continue handling the request
        return await next();
    }
}

