﻿namespace Inventory.Application.Contract.Inventory
{
    public class InventorySearchModel
    {
        public long ProductId { get; set; }
        public bool InStock { get; set; }
    }
}
