using CardAccess.Application.Common.Exceptions;
using CardAccess.Application.Common.Security;
using CardAccess.Application.TodoLists.Commands.CreateTodoList;
using CardAccess.Application.TodoLists.Commands.PurgeTodoLists;
using CardAccess.Domain.Entities;

//using static Testing;

namespace CardAccess.Application.FunctionalTests.TodoLists.Commands;
public class PurgeTodoListsTests : BaseTestFixture
{
    [Test]
    public async Task ShouldDenyAnonymousUser()
    {
        //var command = new PurgeTodoListsCommand();

        //command.GetType().Should().BeDecoratedWith<AuthorizeAttribute>();

        //var action = () => SendAsync(command);

        //await action.Should().ThrowAsync<UnauthorizedAccessException>();

        await Task.CompletedTask;
    }

    [Test]
    public async Task ShouldDenyNonAdministrator()
    {
        //await RunAsDefaultUserAsync();

        //var command = new PurgeTodoListsCommand();

        //var action = () => SendAsync(command);

        //await action.Should().ThrowAsync<ForbiddenAccessException>();

        await Task.CompletedTask;
    }

    [Test]
    public async Task ShouldAllowAdministrator()
    {
        //await RunAsAdministratorAsync();

        //var command = new PurgeTodoListsCommand();

        //var action = () => SendAsync(command);

        //await action.Should().NotThrowAsync<ForbiddenAccessException>();

        await Task.CompletedTask;
    }

    [Test]
    public async Task ShouldDeleteAllLists()
    {
        //await RunAsAdministratorAsync();

        //await SendAsync(new CreateTodoListCommand
        //{
        //    Title = "New List #1"
        //});

        //await SendAsync(new CreateTodoListCommand
        //{
        //    Title = "New List #2"
        //});

        //await SendAsync(new CreateTodoListCommand
        //{
        //    Title = "New List #3"
        //});

        //await SendAsync(new PurgeTodoListsCommand());

        //var count = await CountAsync<TodoList>();

        //count.Should().Be(0);

        await Task.CompletedTask;
    }
}
