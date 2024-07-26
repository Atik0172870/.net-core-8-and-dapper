using System.Data;
using System.Net.Http.Headers;
using CardAccess.Application.Common.Interfaces;
using CardAccess.Application.DTO.Personnel;
using CardAccess.Application.Personnel.Interface;
using CardAccess.Domain.Entities.CaLiveConfig;
using CardAccess.Domain.Repositories.Dapper;
using CardAccess.Infrastructure;
using static CardAccess.Infrastructure.Data.Dapper.DbNames.DbNames;

namespace CardAccess.Application.Personnel.Repository;

public class Personnel(IRepositoty<LiveConfigDb> liveConfig) : IPersonnel
{
    public async Task<IEnumerable<BadgeDto>> GetAllBadge()
    {
        string sp = "mvp_sp_getAllBadge";
        BadgeSpParamsDto param = new BadgeSpParamsDto();
        param.OperatorID = Guid.Parse("E42473BF-F193-4DE6-B9B4-CCFC930DA1BF");
        param.CompanyId = 500501;
        var result = await liveConfig.GetAllBySpAsync<BadgeDto>(sp, param);
        //var result2 = await portal.GetAllBySpAsync<BadgeDto>(sp, param);

        return await Task.FromResult(result);
    }
}
