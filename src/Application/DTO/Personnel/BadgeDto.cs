using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CardAccess.Domain.Entities.CaLiveConfig;

namespace CardAccess.Application.DTO.Personnel;
public class BadgeDto
{
    public Guid Id { get; set; }= Guid.Empty;
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string MiddleName { get; set; } = "";
    public Int64 Badge { get; set; }
    public int Facility { get; set; }
    public byte[]? BadgeImage { get; set; }
    public int Issue { get; set; }
    public bool Enabled { get; set; }
    public int Embossed { get; set; }
    public int CompanyId { get; set; }
    public string CompanyName { get; set; } = "";
}
public class BadgeSpParamsDto
{
    public Guid OperatorID { get; set; } = Guid.Empty;
    public int CompanyId { get; set; }
}


