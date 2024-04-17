using System;
using System.Collections.Generic;

namespace ООО_Техносервис.neModel;

public partial class Equipmenttype
{
    public int TypeId { get; set; }

    public string? TypeName { get; set; }

    public virtual ICollection<Equipment> Equipment { get; } = new List<Equipment>();
}
