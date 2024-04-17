using System;
using System.Collections.Generic;

namespace ООО_Техносервис.neModel;

public partial class Equipment
{
    public int IdEquipment { get; set; }

    public string? NameEquipment { get; set; }

    public int? TypeEquipment { get; set; }

    public string? Description { get; set; }

    public string? CauseEquipment { get; set; }

    public string? SeriaEquipment { get; set; }

    public virtual ICollection<Repairequipment> Repairequipments { get; } = new List<Repairequipment>();

    public virtual Equipmenttype? TypeEquipmentNavigation { get; set; }
}
