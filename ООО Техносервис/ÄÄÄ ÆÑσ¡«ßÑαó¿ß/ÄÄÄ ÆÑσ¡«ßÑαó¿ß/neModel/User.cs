using System;
using System.Collections.Generic;

namespace ООО_Техносервис.neModel;

public partial class User
{
    public int IdUser { get; set; }

    public string? NameUser { get; set; }

    public string? SurNameUser { get; set; }

    public int? RoleId { get; set; }

    public string? PasswordUser { get; set; }

    public string? LoginUser { get; set; }

    public virtual ICollection<Repairequipment> Repairequipments { get; } = new List<Repairequipment>();

    public virtual ICollection<Repairrequest> Repairrequests { get; } = new List<Repairrequest>();

    public virtual Role? Role { get; set; }
}
