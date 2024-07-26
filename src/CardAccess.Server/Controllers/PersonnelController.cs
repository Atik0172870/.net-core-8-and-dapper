using CardAccess.Application.DTO.Personnel;
using CardAccess.Application.Personnel.Interface;
using CardAccess.Domain.Entities.CaLiveConfig;
using CardAccess.Domain.Repositories.Dapper;
using Microsoft.AspNetCore.Mvc;
using static CardAccess.Infrastructure.Data.Dapper.DbNames.DbNames;

namespace CardAccess.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PersonnelController(IRepositoty<LiveConfigDb> liveConfig) : ControllerBase
{
    [HttpGet]
    [Route("getPersonnel")]
    public async Task<IEnumerable<object>> GetPersonnel()
    {
        string sp = "mvp_sp_getAllBadge";
        BadgeSpParamsDto param = new BadgeSpParamsDto();
        param.OperatorID = Guid.Parse("E42473BF-F193-4DE6-B9B4-CCFC930DA1BF");
        param.CompanyId = 500501;
        var d = await liveConfig.GetAllBySpAsync<BadgeDto>(sp, param);
        return await Task.FromResult(d);
    }
}
