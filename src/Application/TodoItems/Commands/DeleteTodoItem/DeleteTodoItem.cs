using CardAccess.Application.Common.Interfaces;
using CardAccess.Domain.Events;

namespace CardAccess.Application.TodoItems.Commands.DeleteTodoItem;

// Define a record representing the command to delete a todo item
public record DeleteTodoItemCommand(int Id) : IRequest;

// Handler for the DeleteTodoItemCommand
public class DeleteTodoItemCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteTodoItemCommand>
{
    private readonly IApplicationDbContext _context = context;

    // Handle method to execute the delete operation
    public async Task Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        // Find the todo item entity by its Id
        var entity = await _context.TodoItems
            .FindAsync([request.Id], cancellationToken);

        // Guard against null entity, throwing an exception if not found
        Guard.Against.NotFound(request.Id, entity);

        // Remove the todo item entity from the context
        _context.TodoItems.Remove(entity);

        // Add a domain event for the deleted todo item
        entity.AddDomainEvent(new TodoItemDeletedEvent(entity));

        // Save changes to the database
        await _context.SaveChangesAsync(cancellationToken);
    }
}

