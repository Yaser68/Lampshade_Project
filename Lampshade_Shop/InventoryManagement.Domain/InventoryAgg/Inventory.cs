using _0_Framework.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory : EntityBase
    {
        public long ProductId { get; private set; }
        public double UnitPrice { get;private set; }
        public bool InStock { get; private set; }
        public List<InventoryOperation> Operations { get; set; }

        public Inventory(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            InStock = false;
        }

        public void EditInventory(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
        }
        public long CalculateCurrentCount()
        {
            var plus = Operations.Where(x => x.Operation).Sum(x => x.Count);
            var minus = Operations.Where(x => !x.Operation).Sum(x => x.Count);

            return plus - minus;
        }

        public void Increase(long count,long operatorId,string description)
        {
            var currnetCount = CalculateCurrentCount() + count;
            var Operation = new InventoryOperation(true, count, operatorId, currnetCount, description, 0, Id);

            Operations.Add(Operation);
            InStock=currnetCount > 0;

        }

        public void Reduce(long count,long operatorId,string description,long orderId)
        {
            var currnetCount = CalculateCurrentCount() + count;
            var Operation = new InventoryOperation(false, count, operatorId, currnetCount, description, orderId, Id);

            Operations.Add(Operation);
            InStock = currnetCount > 0;
        }
    }
}
