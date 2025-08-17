using MTM_WIP_Application_MAUI.Models;
using MTM_WIP_Application_MAUI.Services;
using System.Collections.ObjectModel;

namespace MTM_WIP_Application_MAUI.Pages
{
    public partial class InventoryListPage : ContentPage
    {
        private readonly IInventoryService _inventoryService;
        public ObservableCollection<CurrentInventory> Inventory { get; set; }

        public InventoryListPage()
        {
            InitializeComponent();
            _inventoryService = ServiceHelper.GetService<IInventoryService>();
            Inventory = new ObservableCollection<CurrentInventory>();
            InventoryCollectionView.ItemsSource = Inventory;
            LoadInventoryData();
        }

        private async void LoadInventoryData()
        {
            try
            {
                var inventory = await _inventoryService.GetInventoryAsync();
                Inventory.Clear();
                foreach (var item in inventory)
                {
                    Inventory.Add(item);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load inventory: {ex.Message}", "OK");
            }
        }

        private async void OnBackToMainClicked(object? sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }

    // Helper class for dependency injection in pages
    public static class ServiceHelper
    {
        public static TService GetService<TService>()
            => Current.GetService<TService>();

        public static IServiceProvider Current =>
#if WINDOWS10_0_17763_0_OR_GREATER
            MauiWinUIApplication.Current.Services;
#elif ANDROID
            MauiApplication.Current.Services;
#elif IOS || MACCATALYST
            MauiUIApplicationDelegate.Current.Services;
#else
            null;
#endif
    }
}