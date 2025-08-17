using MTM_WIP_Application_MAUI.Models;
using System.Collections.ObjectModel;

namespace MTM_WIP_Application_MAUI.Pages
{
    public partial class InventoryListPage : ContentPage
    {
        public ObservableCollection<CurrentInventory> Inventory { get; set; }

        public InventoryListPage()
        {
            InitializeComponent();
            Inventory = new ObservableCollection<CurrentInventory>();
            LoadSampleData();
            InventoryCollectionView.ItemsSource = Inventory;
        }

        private void LoadSampleData()
        {
            // TODO: Replace with actual database/storage loading
            Inventory.Add(new CurrentInventory
            {
                Id = 1,
                ItemNumber = "MTM-001",
                Location = "A1-B2",
                Op = "OP10",
                Quantity = 50,
                Notes = "Quality checked",
                User = "ADMIN",
                DateTime = DateTime.Now.AddHours(-2)
            });

            Inventory.Add(new CurrentInventory
            {
                Id = 2,
                ItemNumber = "MTM-002",
                Location = "B3-C4",
                Op = "OP20",
                Quantity = 25,
                Notes = "Pending inspection",
                User = "USER1",
                DateTime = DateTime.Now.AddHours(-1)
            });

            Inventory.Add(new CurrentInventory
            {
                Id = 3,
                ItemNumber = "MTM-003",
                Location = "C5-D6",
                Op = "OP30",
                Quantity = 75,
                Notes = "Ready for shipment",
                User = "USER2",
                DateTime = DateTime.Now.AddMinutes(-30)
            });
        }

        private async void OnBackToMainClicked(object? sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}