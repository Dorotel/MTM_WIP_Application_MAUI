using System.Reflection;

namespace MTM_WIP_Application_MAUI.Models
{
    internal static class AppVariables
    {
        #region User Info

        public static string EnteredUser { get; set; } = "Default User";
        public static string User { get; set; } = "DEFAULT";
        public static string? UserPin { get; set; }
        public static string? UserShift { get; set; }
        public static bool UserTypeAdmin { get; set; } = false;
        public static bool UserTypeReadOnly { get; set; } = false;
        public static bool UserTypeNormal { get; set; } = true;

        public static string UserVersion { get; set; } =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "unknown";

        public static string? UserFullName { get; set; }
        public static string? VisualUserName { get; set; }
        public static string? VisualPassword { get; set; }

        #endregion

        #region Inventory State

        public static int InventoryQuantity { get; set; }
        public static string? PartId { get; set; }
        public static string? PartType { get; set; }
        public static string? Location { get; set; }
        public static string? Operation { get; set; }
        public static string? Notes { get; set; }

        #endregion

        #region Theme & Version

        public static string? LastUpdated { get; set; } = "08/05/2025";
        public static string? ThemeName { get; set; } = "Default";
        public static float ThemeFontSize { get; set; } = 9f;
        public static string? WipServerAddress { get; set; }
        public static string? WipServerPort { get; set; } = "3306";
        public static string? Version { get; set; } = Assembly.GetEntryAssembly()?.GetName().Version?.ToString();

        #endregion

        #region About Variables

        public static string ApplicationName { get; } = "Manitowoc Tool and Manufacturing WIP Application";
        public static string ApplicationAuthor { get; } = @"John Koll";
        public static string ApplicationCopyright { get; } = @"Manitowoc Tool and Manufacturing";
        public static string ApplicationVersion { get; } =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "Unknown";

        #endregion
    }
}