using MTM_WIP_Application_MAUI.Models;
using System.Collections.ObjectModel;

namespace MTM_WIP_Application_MAUI.Services
{
    public interface IInventoryService
    {
        Task<ObservableCollection<CurrentInventory>> GetInventoryAsync();
        Task<bool> AddInventoryAsync(CurrentInventory inventory);
        Task<bool> RemoveInventoryAsync(string partId, string location, int quantity);
        Task<bool> TransferInventoryAsync(string partId, string fromLocation, string toLocation, int quantity);
    }

    public class MockInventoryService : IInventoryService
    {
        private readonly ObservableCollection<CurrentInventory> _inventory;

        public MockInventoryService()
        {
            _inventory = new ObservableCollection<CurrentInventory>
            {
                new CurrentInventory
                {
                    Id = 1,
                    ItemNumber = "MTM-001",
                    Location = "A1-B2",
                    Op = "OP10",
                    Quantity = 50,
                    Notes = "Quality checked",
                    User = "ADMIN",
                    DateTime = DateTime.Now.AddHours(-2)
                },
                new CurrentInventory
                {
                    Id = 2,
                    ItemNumber = "MTM-002",
                    Location = "B3-C4",
                    Op = "OP20",
                    Quantity = 25,
                    Notes = "Pending inspection",
                    User = "USER1",
                    DateTime = DateTime.Now.AddHours(-1)
                },
                new CurrentInventory
                {
                    Id = 3,
                    ItemNumber = "MTM-003",
                    Location = "C5-D6",
                    Op = "OP30",
                    Quantity = 75,
                    Notes = "Ready for shipment",
                    User = "USER2",
                    DateTime = DateTime.Now.AddMinutes(-30)
                }
            };
        }

        public async Task<ObservableCollection<CurrentInventory>> GetInventoryAsync()
        {
            // Simulate async call
            await Task.Delay(100);
            return _inventory;
        }

        public async Task<bool> AddInventoryAsync(CurrentInventory inventory)
        {
            // Simulate async call
            await Task.Delay(100);
            
            inventory.Id = _inventory.Count + 1;
            _inventory.Add(inventory);
            return true;
        }

        public async Task<bool> RemoveInventoryAsync(string partId, string location, int quantity)
        {
            // Simulate async call
            await Task.Delay(100);
            
            var item = _inventory.FirstOrDefault(i => 
                i.ItemNumber.Equals(partId, StringComparison.OrdinalIgnoreCase) && 
                i.Location.Equals(location, StringComparison.OrdinalIgnoreCase));
            
            if (item != null)
            {
                if (item.Quantity >= quantity)
                {
                    item.Quantity -= quantity;
                    if (item.Quantity == 0)
                    {
                        _inventory.Remove(item);
                    }
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> TransferInventoryAsync(string partId, string fromLocation, string toLocation, int quantity)
        {
            // Simulate async call
            await Task.Delay(100);
            
            var fromItem = _inventory.FirstOrDefault(i => 
                i.ItemNumber.Equals(partId, StringComparison.OrdinalIgnoreCase) && 
                i.Location.Equals(fromLocation, StringComparison.OrdinalIgnoreCase));
            
            if (fromItem != null && fromItem.Quantity >= quantity)
            {
                // Remove from source
                fromItem.Quantity -= quantity;
                if (fromItem.Quantity == 0)
                {
                    _inventory.Remove(fromItem);
                }
                
                // Add to destination
                var toItem = _inventory.FirstOrDefault(i => 
                    i.ItemNumber.Equals(partId, StringComparison.OrdinalIgnoreCase) && 
                    i.Location.Equals(toLocation, StringComparison.OrdinalIgnoreCase));
                
                if (toItem != null)
                {
                    toItem.Quantity += quantity;
                }
                else
                {
                    _inventory.Add(new CurrentInventory
                    {
                        Id = _inventory.Count + 1,
                        ItemNumber = partId,
                        Location = toLocation,
                        Op = fromItem.Op,
                        Quantity = quantity,
                        Notes = $"Transferred from {fromLocation}",
                        User = AppVariables.User,
                        DateTime = DateTime.Now
                    });
                }
                return true;
            }
            return false;
        }
    }
}