using System;
using System.Collections.Generic;

namespace ООО_Техносервис.neModel;

public partial class Statusrepair
{
    public int IdStatusRepairs { get; set; }

    public string? StatusName { get; set; }

    public virtual ICollection<Repairequipment> Repairequipments { get; } = new List<Repairequipment>();
}
