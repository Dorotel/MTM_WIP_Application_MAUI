using MTM_MAUI_Application.Models;
using ModelLocation = MTM_MAUI_Application.Models.Location;

namespace MTM_MAUI_Application.Services;

/// <summary>
/// Interface for user operations
/// </summary>
public interface IUserService
{
    Task<User?> GetCurrentUserAsync();
    Task<User?> GetUserByUsernameAsync(string username);
    Task<List<User>> GetAllUsersAsync();
    Task<bool> SetCurrentUserAsync(string username);
    Task<bool> UpdateUserSettingsAsync(User user);
}

/// <summary>
/// Interface for part operations  
/// </summary>
public interface IPartService
{
    Task<List<Part>> GetAllPartsAsync();
    Task<Part?> GetPartByNumberAsync(string partNumber);
    Task<bool> AddPartAsync(Part part);
    Task<bool> UpdatePartAsync(Part part);
    Task<bool> DeletePartAsync(int partId);
}

/// <summary>
/// Interface for location operations
/// </summary>
public interface ILocationService
{
    Task<List<ModelLocation>> GetAllLocationsAsync();
    Task<MTM_MAUI_Application.Models.Location?> GetLocationByNameAsync(string name);
    Task<bool> AddLocationAsync(ModelLocation location);
    Task<bool> UpdateLocationAsync(ModelLocation location);
    Task<bool> DeleteLocationAsync(int locationId);
}

/// <summary>
/// Interface for operation operations
/// </summary>
public interface IOperationService
{
    Task<List<Operation>> GetAllOperationsAsync();
    Task<Operation?> GetOperationByNumberAsync(string number);
    Task<bool> AddOperationAsync(Operation operation);
    Task<bool> UpdateOperationAsync(Operation operation);
    Task<bool> DeleteOperationAsync(int operationId);
}

/// <summary>
/// Interface for transaction operations
/// </summary>
public interface ITransactionService
{
    Task<List<Transaction>> GetTransactionsAsync(DateTime? startDate = null, DateTime? endDate = null);
    Task<List<Transaction>> SearchTransactionsAsync(string searchTerm);
    Task<bool> AddTransactionAsync(Transaction transaction);
    Task<List<Transaction>> GetTransactionsByUserAsync(string username);
    Task<List<Transaction>> GetTransactionsByPartAsync(string partId);
}

/// <summary>
/// Interface for theme operations
/// </summary>
public interface IThemeService
{
    Task ApplyThemeAsync(string themeName);
    Task<string> GetCurrentThemeAsync();
    Task<List<string>> GetAvailableThemesAsync();
    Task SetFontSizeAsync(int fontSize);
    Task<int> GetFontSizeAsync();
}

/// <summary>
/// Interface for connection monitoring
/// </summary>
public interface IConnectionService
{
    Task<bool> TestConnectionAsync();
    Task<int> GetConnectionStrengthAsync();
    event EventHandler<bool> ConnectionStatusChanged;
    Task StartMonitoringAsync();
    Task StopMonitoringAsync();
}

/// <summary>
/// Interface for inventory operations
/// </summary>
public interface IInventoryService
{
    Task<List<InventoryItem>> GetInventoryByPartIdAsync(string partId);
    Task<List<InventoryItem>> GetInventoryByPartIdAndOperationAsync(string partId, string operation);
    Task<bool> AddInventoryItemAsync(InventoryItem item);
    Task<bool> RemoveInventoryItemAsync(int inventoryId, int quantity, string user, string notes = "");
    Task<bool> TransferInventoryAsync(int inventoryId, string toLocation, int quantity, string user, string notes = "");
    Task<List<InventoryItem>> SearchInventoryAsync(string searchTerm);
}

/// <summary>
/// Interface for error handling services
/// </summary>
public interface IErrorHandlerService
{
    Task HandleExceptionAsync(Exception exception, string context = "");
    Task ShowErrorAsync(string title, string message);
    Task ShowWarningAsync(string title, string message);
    Task ShowInfoAsync(string title, string message);
    Task<bool> ShowConfirmationAsync(string title, string message);
}