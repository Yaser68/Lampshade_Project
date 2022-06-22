using _0_Framework.Application;
using Inventory.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using System;
using System.Collections.Generic;

namespace InventoryManagement.Application
{
    public class InventoryApplication : IInventoryApplication

    {

        private readonly IInventoryRepository _inventoryRepository;

        public InventoryApplication(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public OperationResult Create(CreateInventory command)
        {
            var operation=new OperationResult();
            if (_inventoryRepository.Exists(x => x.ProductId == command.ProductId))
                return operation.Failed(DefultMessage.DuplicatedMessage);

            var inventory = new InventoryManagement.Domain.InventoryAgg.Inventory(command.ProductId, command.UnitPrice);

            _inventoryRepository.Create(inventory);
            _inventoryRepository.SaveChanges();
            return operation.Succedded();


        }

        public OperationResult Edit(EditInventory command)
        {
            var operation = new OperationResult();

            var inventory=_inventoryRepository.Get(command.Id);
            if (inventory == null)
                return operation.Failed(DefultMessage.NotFoundMessage);

            if (_inventoryRepository.Exists(x => x.ProductId == command.ProductId && x.Id !=command.Id))
                return operation.Failed(DefultMessage.DuplicatedMessage);

            inventory.EditInventory(command.ProductId,command.UnitPrice);
            _inventoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditInventory GetDetails(long id)
        {
            return _inventoryRepository.GetDetails(id);
        }

        public OperationResult Increase(IncreaseInventory command)
        {
            var operation = new OperationResult();

            var inventory = _inventoryRepository.Get(command.InventoryId);
            if (inventory == null)
                return operation.Failed(DefultMessage.NotFoundMessage);


            const long operatorId = 1;

            inventory.Increase(command.Count, operatorId, command.Description);
            _inventoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Reduce(ReduceInventory command)
        {
            var operation = new OperationResult();

            var inventory = _inventoryRepository.Get(command.InventoryId);
            if (inventory == null)
                return operation.Failed(DefultMessage.NotFoundMessage);


            const long operatorId = 1;

            inventory.Reduce(command.Count, operatorId, command.Description,command.OrderId);
            _inventoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Reduce(List<ReduceInventory> command)
        {
            var operation = new OperationResult();

            foreach (var inventory in command)
            {
                var inventory1 = _inventoryRepository.GetInventoryBy(inventory.ProductId);
                const long operatorId = 1;
                inventory1.Reduce(command.Count, operatorId, inventory.Description, inventory.OrderId);
            }
            _inventoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            return _inventoryRepository.Search(searchModel);
        }
    }
}
