using MTM_MAUI_Application.Models;
using MTM_MAUI_Application.Services;

namespace MTM_MAUI_Application.Services
{
    // Mock implementations for demo purposes
    public class MockInventoryService : IInventoryService
    {
        private readonly List<InventoryItem> _inventory = new();

        public async Task<bool> AddInventoryItemAsync(InventoryItem item)
        {
            await Task.Delay(100); // Simulate async work
            item.Id = _inventory.Count + 1;
            item.CreatedDate = DateTime.Now;
            _inventory.Add(item);
            return true;
        }

        public async Task<List<InventoryItem>> GetInventoryByPartIdAsync(string partId)
        {
            await Task.Delay(100);
            return _inventory.Where(i => i.PartId == partId).ToList();
        }

        public async Task<List<InventoryItem>> GetInventoryByPartIdAndOperationAsync(string partId, string operation)
        {
            await Task.Delay(100);
            return _inventory.Where(i => i.PartId == partId && i.Operation == operation).ToList();
        }

        public async Task<bool> RemoveInventoryItemAsync(int inventoryId, int quantity, string user, string notes = "")
        {
            await Task.Delay(100);
            var item = _inventory.FirstOrDefault(i => i.Id == inventoryId);
            if (item != null && item.Quantity >= quantity)
            {
                item.Quantity -= quantity;
                if (item.Quantity <= 0)
                {
                    _inventory.Remove(item);
                }
                return true;
            }
            return false;
        }

        public async Task<bool> TransferInventoryAsync(int inventoryId, string toLocation, int quantity, string user, string notes = "")
        {
            await Task.Delay(100);
            var item = _inventory.FirstOrDefault(i => i.Id == inventoryId);
            if (item != null && item.Quantity >= quantity)
            {
                // Create new item in destination
                var newItem = new InventoryItem
                {
                    Id = _inventory.Count + 1,
                    PartId = item.PartId,
                    Location = toLocation,
                    Operation = item.Operation,
                    Quantity = quantity,
                    User = user,
                    Notes = notes,
                    ItemType = item.ItemType,
                    CreatedDate = DateTime.Now
                };
                _inventory.Add(newItem);
                
                // Reduce from source
                item.Quantity -= quantity;
                if (item.Quantity <= 0)
                {
                    _inventory.Remove(item);
                }
                return true;
            }
            return false;
        }

        public async Task<List<InventoryItem>> SearchInventoryAsync(string searchTerm)
        {
            await Task.Delay(100);
            return _inventory.Where(i => 
                i.PartId.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                i.Location.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                i.Operation.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }
    }

    public class MockPartService : IPartService
    {
        private readonly List<Part> _parts = new()
        {
            new Part { Id = 1, PartNumber = "PART001", Description = "Engine Block", PartType = "Main engine component" },
            new Part { Id = 2, PartNumber = "PART002", Description = "Cylinder Head", PartType = "Top engine component" },
            new Part { Id = 3, PartNumber = "PART003", Description = "Piston", PartType = "Moving engine part" }
        };

        public async Task<List<Part>> GetAllPartsAsync()
        {
            await Task.Delay(100);
            return _parts.ToList();
        }

        public async Task<Part?> GetPartByNumberAsync(string partNumber)
        {
            await Task.Delay(100);
            return _parts.FirstOrDefault(p => p.PartNumber == partNumber);
        }

        public async Task<bool> AddPartAsync(Part part)
        {
            await Task.Delay(100);
            part.Id = _parts.Max(p => p.Id) + 1;
            _parts.Add(part);
            return true;
        }

        public async Task<bool> UpdatePartAsync(Part part)
        {
            await Task.Delay(100);
            var existing = _parts.FirstOrDefault(p => p.Id == part.Id);
            if (existing != null)
            {
                _parts.Remove(existing);
                _parts.Add(part);
                return true;
            }
            return false;
        }

        public async Task<bool> DeletePartAsync(int partId)
        {
            await Task.Delay(100);
            var part = _parts.FirstOrDefault(p => p.Id == partId);
            if (part != null)
            {
                _parts.Remove(part);
                return true;
            }
            return false;
        }
    }

    public class MockLocationService : ILocationService
    {
        private readonly List<MTM_MAUI_Application.Models.Location> _locations = new()
        {
            new MTM_MAUI_Application.Models.Location { Id = 1, Name = "Warehouse A", Description = "Main storage area" },
            new MTM_MAUI_Application.Models.Location { Id = 2, Name = "Warehouse B", Description = "Secondary storage" },
            new MTM_MAUI_Application.Models.Location { Id = 3, Name = "Production Floor", Description = "Manufacturing area" }
        };

        public async Task<List<MTM_MAUI_Application.Models.Location>> GetAllLocationsAsync()
        {
            await Task.Delay(100);
            return _locations.ToList();
        }

        public async Task<MTM_MAUI_Application.Models.Location?> GetLocationByNameAsync(string name)
        {
            await Task.Delay(100);
            return _locations.FirstOrDefault(l => l.Name == name);
        }

        public async Task<bool> AddLocationAsync(MTM_MAUI_Application.Models.Location location)
        {
            await Task.Delay(100);
            location.Id = _locations.Max(l => l.Id) + 1;
            _locations.Add(location);
            return true;
        }

        public async Task<bool> UpdateLocationAsync(MTM_MAUI_Application.Models.Location location)
        {
            await Task.Delay(100);
            var existing = _locations.FirstOrDefault(l => l.Id == location.Id);
            if (existing != null)
            {
                _locations.Remove(existing);
                _locations.Add(location);
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteLocationAsync(int locationId)
        {
            await Task.Delay(100);
            var location = _locations.FirstOrDefault(l => l.Id == locationId);
            if (location != null)
            {
                _locations.Remove(location);
                return true;
            }
            return false;
        }
    }

    public class MockOperationService : IOperationService
    {
        private readonly List<Operation> _operations = new()
        {
            new Operation { Id = 1, Number = "OP001", Description = "CNC operations" },
            new Operation { Id = 2, Number = "OP002", Description = "Component assembly" },
            new Operation { Id = 3, Number = "OP003", Description = "Final inspection" }
        };

        public async Task<List<Operation>> GetAllOperationsAsync()
        {
            await Task.Delay(100);
            return _operations.ToList();
        }

        public async Task<Operation?> GetOperationByNumberAsync(string number)
        {
            await Task.Delay(100);
            return _operations.FirstOrDefault(o => o.Number == number);
        }

        public async Task<bool> AddOperationAsync(Operation operation)
        {
            await Task.Delay(100);
            operation.Id = _operations.Max(o => o.Id) + 1;
            _operations.Add(operation);
            return true;
        }

        public async Task<bool> UpdateOperationAsync(Operation operation)
        {
            await Task.Delay(100);
            var existing = _operations.FirstOrDefault(o => o.Id == operation.Id);
            if (existing != null)
            {
                _operations.Remove(existing);
                _operations.Add(operation);
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteOperationAsync(int operationId)
        {
            await Task.Delay(100);
            var operation = _operations.FirstOrDefault(o => o.Id == operationId);
            if (operation != null)
            {
                _operations.Remove(operation);
                return true;
            }
            return false;
        }
    }

    public class MockUserService : IUserService
    {
        private User? _currentUser = new User { Id = 1, Username = "DemoUser", FullName = "Demo User" };

        public async Task<User?> GetCurrentUserAsync()
        {
            await Task.Delay(100);
            return _currentUser;
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            await Task.Delay(100);
            return username == "DemoUser" ? _currentUser : null;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            await Task.Delay(100);
            return new List<User> { _currentUser! };
        }

        public async Task<bool> SetCurrentUserAsync(string username)
        {
            await Task.Delay(100);
            return username == "DemoUser";
        }

        public async Task<bool> UpdateUserSettingsAsync(User user)
        {
            await Task.Delay(100);
            if (_currentUser?.Id == user.Id)
            {
                _currentUser = user;
                return true;
            }
            return false;
        }
    }

    public class MockErrorHandlerService : IErrorHandlerService
    {
        public async Task HandleExceptionAsync(Exception exception, string context)
        {
            Console.WriteLine($"Error in {context}: {exception.Message}");
            await Task.CompletedTask;
        }

        public async Task ShowErrorAsync(string title, string message)
        {
            Console.WriteLine($"ERROR - {title}: {message}");
            await Task.CompletedTask;
        }

        public async Task ShowInfoAsync(string title, string message)
        {
            Console.WriteLine($"INFO - {title}: {message}");
            await Task.CompletedTask;
        }

        public async Task ShowWarningAsync(string title, string message)
        {
            Console.WriteLine($"WARNING - {title}: {message}");
            await Task.CompletedTask;
        }

        public async Task<bool> ShowConfirmationAsync(string title, string message)
        {
            Console.WriteLine($"CONFIRM - {title}: {message} (Returning true for demo)");
            await Task.CompletedTask;
            return true;
        }
    }
}