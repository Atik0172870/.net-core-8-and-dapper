namespace CardAccess.Domain.Repositories;
public interface ITodoRepository
{
    Task<IEnumerable<TodoList>> GetTodosAsync();
}
