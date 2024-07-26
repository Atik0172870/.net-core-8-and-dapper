using CardAccess.Application.DTO.Personnel;
using CardAccess.Infrastructure.Generic;

namespace CardAccess.Application.Personnel.Interface;
public interface IPersonnel 
{
    Task<IEnumerable<BadgeDto>> GetAllBadge();
}
