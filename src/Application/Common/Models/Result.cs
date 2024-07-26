namespace CardAccess.Application.Common.Models;

// Represents the result of an operation, indicating whether the operation succeeded and providing any associated errors.
public class Result
{
    // Constructor initializes the Result with a success status and any associated errors.
    internal Result(bool succeeded, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Errors = errors.ToArray();
    }

    // Gets a value indicating whether the operation succeeded.
    public bool Succeeded { get; init; }

    // Gets an array of errors associated with the operation.
    public string[] Errors { get; init; }

    // Creates a new Result instance indicating a successful operation with no errors.
    public static Result Success()
    {
        return new Result(true, []);
    }

    // Creates a new Result instance indicating a failed operation with the specified errors.
    public static Result Failure(IEnumerable<string> errors)
    {
        return new Result(false, errors);
    }
}
