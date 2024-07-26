using CardAccess.Application.Common.Interfaces;
using CardAccess.Domain.Entities;
using CardAccess.Domain.Events;

namespace CardAccess.Application.TodoItems.Commands.CreateTodoItem;
// Represents a command to create a new todo item.
public record CreateTodoItemCommand : IRequest<int>
{
    // Gets or initializes the identifier of the todo list to which the item belongs.
    public int ListId { get; init; }

    // Gets or initializes the title of the todo item.
    public string? Title { get; init; }
}

// Handles the CreateTodoItemCommand by creating a new todo item in the database.
public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, int>
{
    private readonly IApplicationDbContext _context;

    // Constructor initializes the handler with the application database context.
    public CreateTodoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    // Handles the command by creating a new todo item entity, adding it to the database, and returning its identifier.
    public async Task<int> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new TodoItem
        {
            ListId = request.ListId,
            Title = request.Title,
            Done = false
        };

        // Adds a domain event indicating that a todo item has been created.
        entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

        // Adds the new todo item entity to the database.
        _context.TodoItems.Add(entity);

        // Saves changes asynchronously to the database.
        await _context.SaveChangesAsync(cancellationToken);

        // Returns the identifier of the newly created todo item.
        return entity.Id;
    }
}
