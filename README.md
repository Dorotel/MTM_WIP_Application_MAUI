# MTM WIP Application - MAUI

This is a cross-platform .NET MAUI version of the Manitowoc Tool and Manufacturing Work in Progress (WIP) Inventory Management Application.

## Project Overview

This application has been migrated from a Windows Forms application to .NET MAUI to enable cross-platform deployment on Android, iOS, macOS, and Windows platforms.

## Features

- **Inventory Management**: Add, remove, and transfer inventory items
- **Real-time Status**: View current inventory levels and locations
- **User Management**: Track which user performed operations
- **Cross-Platform**: Runs on mobile and desktop platforms
- **Modern UI**: Touch-friendly interface optimized for various screen sizes

## Architecture

### Models
- `AppVariables`: Application-wide settings and user information
- `CurrentInventory`: Represents inventory items with location, quantity, and metadata
- `Transaction`: Tracks inventory transactions (IN, OUT, TRANSFER)
- `User`: User authentication and profile management

### Services
- `IInventoryService`: Interface for inventory data operations
- `MockInventoryService`: In-memory implementation for development/testing

### Pages
- `MainPage`: Primary inventory entry and management interface
- `InventoryListPage`: View current inventory items with details

## Getting Started

### Prerequisites
- .NET 8.0 SDK or later
- Visual Studio 2022 or Visual Studio Code with MAUI workloads installed

### Building the Application

```bash
# Restore dependencies
dotnet restore

# Build the application
dotnet build

# Run on specific platform (when workloads are available)
dotnet build -t:Run -f net8.0-android
dotnet build -t:Run -f net8.0-ios
dotnet build -t:Run -f net8.0-windows10.0.19041.0
```

## Migration Notes

This MAUI application was created by migrating business logic from the original WinForms MTM WIP Application, including:

1. **Business Models**: Adapted inventory, transaction, and user models for cross-platform use
2. **Service Architecture**: Implemented dependency injection for data access
3. **UI Modernization**: Converted Windows Forms controls to MAUI XAML pages
4. **Cross-Platform Compatibility**: Ensured code works across all target platforms

## Configuration

The application supports both development and production configurations:

- **Development**: Uses local database server or localhost
- **Production**: Connects to production server at 172.16.1.104:3306

## Database Integration

Currently uses a mock service for demonstration. To integrate with the actual MySQL database:

1. Install MySQL connector package
2. Implement `IDatabaseService` with actual MySQL connection
3. Replace `MockInventoryService` registration in `MauiProgram.cs`

## Future Enhancements

- [ ] Database integration with MySQL
- [ ] User authentication system
- [ ] Barcode scanning capabilities
- [ ] Offline synchronization
- [ ] Reporting and analytics
- [ ] Transfer workflow implementation

## Support

For questions or issues, contact the development team at Manitowoc Tool and Manufacturing.

---

*Copyright © Manitowoc Tool and Manufacturing. All rights reserved.*