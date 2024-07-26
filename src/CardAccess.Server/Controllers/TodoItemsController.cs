using CardAccess.Application.Common.Models;
using CardAccess.Application.TodoItems.Commands.CreateTodoItem;
using CardAccess.Application.TodoItems.Commands.DeleteTodoItem;
using CardAccess.Application.TodoItems.Commands.UpdateTodoItem;
using CardAccess.Application.TodoItems.Commands.UpdateTodoItemDetail;
using CardAccess.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CardAccess.Server.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TodoItemsController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<PaginatedList<TodoItemBriefDto>> GetTodoItemsWithPagination([AsParameters] GetTodoItemsWithPaginationQuery query)
        => await sender.Send(query);

    [HttpPost]
    public async Task<int> CreateTodoItem(CreateTodoItemCommand command)
        => await sender.Send(command);

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTodoItem(int id, UpdateTodoItemCommand command)
    {
        if (id != command.Id) return BadRequest();
        await sender.Send(command);
        return NoContent();
    }

    [HttpPut("UpdateDetail/{id}")]
    public async Task<IActionResult> UpdateTodoItemDetail(int id, UpdateTodoItemDetailCommand command)
    {
        if (id != command.Id) return BadRequest();
        await sender.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoItem(int id)
    {
        await sender.Send(new DeleteTodoItemCommand(id));
        return NoContent();
    }
}
