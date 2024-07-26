using CardAccess.Domain.Entities;

namespace CardAccess.Application.Common.Models;

// Represents a data transfer object (DTO) for lookup purposes.
public class LookupDto
{
    // Gets or sets the identifier of the lookup item.
    public int Id { get; init; }

    // Gets or sets the title of the lookup item.
    public string? Title { get; init; }

    // Private mapping profile for AutoMapper configurations.
    private class Mapping : Profile
    {
        // Initializes mappings between domain entities and LookupDto.
        public Mapping()
        {
            CreateMap<TodoList, LookupDto>();
            CreateMap<TodoItem, LookupDto>();
        }
    }
}
