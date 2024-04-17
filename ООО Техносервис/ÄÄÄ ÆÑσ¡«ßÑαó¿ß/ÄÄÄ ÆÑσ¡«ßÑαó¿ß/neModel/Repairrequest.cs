using System;
using System.Collections.Generic;

namespace ООО_Техносервис.neModel;

public partial class Repairrequest
{
    public int IdRepairRequest { get; set; }

    public DateOnly? DateRequest { get; set; }

    public int? IdClient { get; set; }

    public string? Priority { get; set; }

    public virtual User? IdClientNavigation { get; set; }

    public virtual ICollection<Repairequipment> Repairequipments { get; } = new List<Repairequipment>();
}
