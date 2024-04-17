using System;
using System.Collections.Generic;

namespace ООО_Техносервис.neModel;

public partial class Repairequipment
{
    public int IdRepairEquipment { get; set; }

    public int? IdRepair { get; set; }

    public int? IdEquipment { get; set; }

    public decimal? Cost { get; set; }

    public int? Status { get; set; }

    public string? Comment { get; set; }

    public int? Executor { get; set; }

    public virtual User? ExecutorNavigation { get; set; }

    public virtual Equipment? IdEquipmentNavigation { get; set; }

    public virtual Repairrequest? IdRepairNavigation { get; set; }

    public virtual Statusrepair? StatusNavigation { get; set; }
}
