using System.Data;
using CardAccess.Domain.Entities;
using CardAccess.Domain.Repositories;
using CardAccess.Infrastructure.Interfaces;
using Dapper;

namespace CardAccess.Infrastructure.Repositories;
public class TodoRepository(IDefaultDbConnectionFactory defaultDbConnectionFactory) : ITodoRepository
{
    public async Task<IEnumerable<TodoList>> GetTodosAsync()
    {
        string sql = @"SELECT L.Id, L.Title, L.Colour_Code, L.Created, L.CreatedBy, L.LastModified, L.LastModifiedBy, I.Id AS ItemId, I.ListId, I.Title, I.Note, I.Priority, I.Reminder, I.Done, I.Created, I.CreatedBy, I.LastModified, I.LastModifiedBy FROM TodoLists AS L
        LEFT JOIN dbo.TodoItems AS I ON L.Id = I.ListId"
        ;

        var todoLists = new Dictionary<int, TodoList>();

        IDbConnection connection = defaultDbConnectionFactory.CreateConnection();
        var lists = await connection.QueryAsync<TodoList, TodoItem, TodoList>(
            sql,
            (todoList, todoItem) =>
            {
                if (!todoLists.TryGetValue(todoList.Id, out var todoListEntry))
                {
                    todoListEntry = todoList;
                    todoLists.Add(todoListEntry.Id, todoListEntry);
                }

                if (todoItem != null)
                {
                    todoListEntry.Items.Add(todoItem);
                }

                return todoListEntry; // Return the mapped todoListEntry
            },
            splitOn: "ItemId"
        );

        return lists;
    }
}
