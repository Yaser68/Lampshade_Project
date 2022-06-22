using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Contract.Inventory
{
    public class CreateInventory
    {
        public long ProductId { get;  set; }
        public double UnitPrice { get;  set; }
    }
}
