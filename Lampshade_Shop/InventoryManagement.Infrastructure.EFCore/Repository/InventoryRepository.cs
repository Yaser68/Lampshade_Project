using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Inventory.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.EFCore.Repository
{
    public class InventoryRepository : RepositoryBase<long, Domain.InventoryAgg.Inventory>, IInventoryRepository
    {

        private readonly InventoryContext _inventoryContext;
        private readonly ShopContext _shopContext;
        public InventoryRepository(InventoryContext context, ShopContext shopContext, InventoryContext inventoryContext) : base(context)
        {
            _shopContext = shopContext;
            _inventoryContext = inventoryContext;
        }

        public EditInventory GetDetails(long id)
        {
            return _inventoryContext.inventory.Select(x=>new EditInventory 
            {
            Id = x.Id,
            ProductId = x.ProductId,
            UnitPrice = x.UnitPrice,
            }).FirstOrDefault(x=>x.Id == id);
        }

        public Domain.InventoryAgg.Inventory GetInventoryBy(long productId)
        {
            return _inventoryContext.inventory.FirstOrDefault(x=> x.ProductId == productId);
        }

        public List<InventoryOperationViewModel> Log(long inventoryId)
        {
            var inventory=_inventoryContext.inventory.FirstOrDefault(x=>x.Id==inventoryId);
            return inventory.Operations.Select(x=> new InventoryOperationViewModel 
            {
            Id=x.Id,
            Operation=x.Operation,
            OperationDate=x.OperationDate.ToFarsi(),
            OrderId=x.OrderId,
            Count=x.Count,
            Description=x.Description,
            OperatorId=x.OperatorId,
            Operator="مدیر سیستم",
            CurrentCount=x.CurrentCount
            

            
            })
                .OrderByDescending(x=>x.Id).ToList();
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            var products = _shopContext.products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _inventoryContext.inventory.Select(x => new InventoryViewModel
            {
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                InStock = x.InStock,
                ProductId = x.ProductId,
                CurrentCount = x.CalculateCurrentCount(),
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            if (searchModel.InStock)
                query = query.Where(x => !x.InStock);

            var inventory = query.OrderByDescending(x => x.Id).ToList();

            inventory.ForEach(item =>
                item.Product = products.FirstOrDefault(x => x.Id == item.ProductId)?.Name);

            return inventory;
        }
    }
}
