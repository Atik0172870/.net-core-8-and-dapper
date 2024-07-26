using System.Data;
using CardAccess.Application.Common.Models;
using CardAccess.Application.Common.Security;
using CardAccess.Domain.Entities;
using CardAccess.Domain.Enums;
using CardAccess.Domain.Repositories;

namespace CardAccess.Application.TodoLists.Queries.GetTodos;
[Authorize]
public record GetTodosQuery : IRequest<TodosVm>;

public class GetTodosQueryHandler(ITodoRepository todoRepository, IMapper mapper) :
    IRequestHandler<GetTodosQuery, TodosVm>
{
    public async Task<TodosVm> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<TodoList> todoList = await todoRepository.GetTodosAsync();

        List<TodoListDto> lists = [.. todoList
            .AsQueryable()
            .ProjectTo<TodoListDto>(mapper.ConfigurationProvider)
            .OrderBy(t => t.Title)];

        List<LookupDto> priorityLevels = [.. Enum.GetValues(typeof(PriorityLevel))
               .Cast<PriorityLevel>()
               .Select(p => new LookupDto { Id = (int)p, Title = p.ToString() })];

        return new TodosVm
        {
            PriorityLevels = priorityLevels,
            Lists = lists
        };
    }
}
