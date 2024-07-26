using FluentValidation.Results;

namespace CardAccess.Application.Common.Exceptions;
// Represents an exception thrown when one or more validation failures occur.
public class ValidationException : Exception
{
    // Constructor initializes the ValidationException with a default message and initializes the Errors dictionary.
    public ValidationException() : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    // Constructor initializes the ValidationException with a collection of ValidationFailure instances.
    // It groups the failures by property name and populates the Errors dictionary accordingly.
    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

    // Gets the dictionary of validation errors, where the key is the property name and the value is an array of error messages.
    public IDictionary<string, string[]> Errors { get; }
}

