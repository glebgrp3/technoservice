using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ООО_Техносервис.neModel;

namespace ООО_Техносервис.neModel
{
    public partial class Repairrequest
    {
        public string StatusRequest
        {
            get
            {
                var listEq = Demoexm1Context._context.Repairequipments.Where(x => x.IdRepair == IdRepairRequest).Where(x => x.Status == 2 || x.Status == 1).ToList();
                if (listEq.Count > 0)
                {
                    if (listEq.Where(x=>x.Status==1).ToList().Count>0)
                            return "В ожидании";
                   
                    return "В работе";
                }

                return "Выполнен";
            }
        }

        public string FullNameClient
        {
            get
            {
                var name = Demoexm1Context._context.Users.FirstOrDefault(x => x.IdUser == IdClient);
                return $"{name.NameUser} {name.SurNameUser}";
            }
        }
    }
}
