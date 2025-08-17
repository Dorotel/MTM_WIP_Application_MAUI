using MTM_WIP_Application_MAUI.Models;

namespace MTM_WIP_Application_MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            InitializeUserInterface();
        }

        private void InitializeUserInterface()
        {
            // Set user information
            UserLabel.Text = $"User: {AppVariables.EnteredUser}";
            VersionLabel.Text = $"Version: {AppVariables.ApplicationVersion}";
            StatusLabel.Text = "Ready for inventory operations";
        }

        private async void OnAddInventoryClicked(object? sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                var inventory = new CurrentInventory
                {
                    ItemNumber = PartIdEntry.Text?.Trim() ?? string.Empty,
                    Location = LocationEntry.Text?.Trim() ?? string.Empty,
                    Op = OperationEntry.Text?.Trim() ?? string.Empty,
                    Quantity = int.Parse(QuantityEntry.Text?.Trim() ?? "0"),
                    Notes = NotesEntry.Text?.Trim() ?? string.Empty,
                    User = AppVariables.User,
                    DateTime = DateTime.Now
                };

                // TODO: Add to database/storage
                StatusLabel.Text = $"Added {inventory.Quantity} of {inventory.ItemNumber} to {inventory.Location}";
                ClearInputs();
                
                await DisplayAlert("Success", $"Successfully added {inventory.Quantity} units of {inventory.ItemNumber}", "OK");
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Error: Failed to add inventory";
                await DisplayAlert("Error", $"Failed to add inventory: {ex.Message}", "OK");
            }
        }

        private async void OnRemoveInventoryClicked(object? sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                var quantity = int.Parse(QuantityEntry.Text?.Trim() ?? "0");
                var partId = PartIdEntry.Text?.Trim() ?? string.Empty;
                var location = LocationEntry.Text?.Trim() ?? string.Empty;

                // TODO: Remove from database/storage
                StatusLabel.Text = $"Removed {quantity} of {partId} from {location}";
                ClearInputs();
                
                await DisplayAlert("Success", $"Successfully removed {quantity} units of {partId}", "OK");
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Error: Failed to remove inventory";
                await DisplayAlert("Error", $"Failed to remove inventory: {ex.Message}", "OK");
            }
        }

        private async void OnTransferInventoryClicked(object? sender, EventArgs e)
        {
            // TODO: Navigate to transfer page or show transfer dialog
            await DisplayAlert("Transfer", "Transfer functionality will be implemented in a future update", "OK");
        }

        private async void OnViewInventoryClicked(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.InventoryListPage());
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(PartIdEntry.Text))
            {
                DisplayAlert("Validation Error", "Part ID is required", "OK");
                return false;
            }

            if (string.IsNullOrWhiteSpace(LocationEntry.Text))
            {
                DisplayAlert("Validation Error", "Location is required", "OK");
                return false;
            }

            if (string.IsNullOrWhiteSpace(QuantityEntry.Text) || !int.TryParse(QuantityEntry.Text, out int quantity) || quantity <= 0)
            {
                DisplayAlert("Validation Error", "Valid quantity is required", "OK");
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            PartIdEntry.Text = string.Empty;
            LocationEntry.Text = string.Empty;
            OperationEntry.Text = string.Empty;
            QuantityEntry.Text = string.Empty;
            NotesEntry.Text = string.Empty;
        }
    }
}