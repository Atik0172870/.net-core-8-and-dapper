using CardAccess.Application.TodoLists.Commands.CreateTodoList;
using CardAccess.Application.TodoLists.Commands.DeleteTodoList;
using CardAccess.Application.TodoLists.Commands.UpdateTodoList;
using CardAccess.Application.TodoLists.Queries.GetTodos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CardAccess.Server.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TodoListsController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<TodosVm> GetTodoLists() => await sender.Send(new GetTodosQuery());

    [HttpPost]
    public async Task<int> CreateTodoList(CreateTodoListCommand command) => await sender.Send(command);

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTodoList(int id, UpdateTodoListCommand command)
    {
        if (id != command.Id) return BadRequest();
        await sender.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoList(int id)
    {
        await sender.Send(new DeleteTodoListCommand(id));
        return NoContent();
    }
}
