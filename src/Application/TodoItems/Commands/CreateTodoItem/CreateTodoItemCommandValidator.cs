namespace CardAccess.Application.TodoItems.Commands.CreateTodoItem;

// Define the validator class for the CreateTodoItemCommand
public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
{
    // Constructor to define validation rules
    public CreateTodoItemCommandValidator()
    {
        // Rule for the Title property
        RuleFor(v => v.Title)
            // Ensure the Title is not empty
            .NotEmpty().WithMessage("Title is required.")
            // Ensure the Title does not exceed 200 characters
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");
    }
}

