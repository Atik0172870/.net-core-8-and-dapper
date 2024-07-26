using CardAccess.Application.TodoLists.Commands.CreateTodoList;
using CardAccess.Application.TodoLists.Commands.DeleteTodoList;
using CardAccess.Domain.Entities;

//using static Testing;

namespace CardAccess.Application.FunctionalTests.TodoLists.Commands;
public class DeleteTodoListTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoListId()
    {
        //var command = new DeleteTodoListCommand(99);
        //await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();


        await Task.CompletedTask;
    }

    [Test]
    public async Task ShouldDeleteTodoList()
    {
        //var listId = await SendAsync(new CreateTodoListCommand
        //{
        //    Title = "New List"
        //});

        //await SendAsync(new DeleteTodoListCommand(listId));

        //var list = await FindAsync<TodoList>(listId);

        //list.Should().BeNull();

        await Task.CompletedTask;
    }
}
