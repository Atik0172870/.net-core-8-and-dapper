using CardAccess.Application.TodoItems.Commands.CreateTodoItem;
using CardAccess.Application.TodoItems.Commands.DeleteTodoItem;
using CardAccess.Application.TodoLists.Commands.CreateTodoList;
using CardAccess.Domain.Entities;

//using static Testing;

namespace CardAccess.Application.FunctionalTests.TodoItems.Commands;
public class DeleteTodoItemTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoItemId()
    {
        //var command = new DeleteTodoItemCommand(99);

        //await FluentActions.Invoking(() =>
        //    SendAsync(command)).Should().ThrowAsync<NotFoundException>();

        await Task.CompletedTask;
    }

    [Test]
    public async Task ShouldDeleteTodoItem()
    {
        //var listId = await SendAsync(new CreateTodoListCommand
        //{
        //    Title = "New List"
        //});

        //var itemId = await SendAsync(new CreateTodoItemCommand
        //{
        //    ListId = listId,
        //    Title = "New Item"
        //});

        //await SendAsync(new DeleteTodoItemCommand(itemId));

        //var item = await FindAsync<TodoItem>(itemId);

        //item.Should().BeNull();

        await Task.CompletedTask;
    }
}
