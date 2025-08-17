using System.Net;
using System.Net.Sockets;

namespace MTM_WIP_Application_MAUI.Models
{
    public class User
    {
        #region Properties

        public static string FullName { get; set; } = string.Empty;
        public string HideChangeLog { get; set; } = "false";
        public int Id { get; set; } = 0;
        public string LastShownVersion { get; set; } = "0.0.0.0";
        public string Pin { get; set; } = "0000";
        public string Shift { get; set; } = string.Empty;
        public int ThemeFontSize { get; set; } = 9;
        public string ThemeName { get; set; } = "Default";
        public string UserName { get; set; } = string.Empty;
        public static string VisualPassword { get; set; } = "Password";
        public static string VisualUserName { get; set; } = "User Name";
        public bool VitsUser { get; set; } = false;
        
        public static string Database
        {
            get => _database ?? (
#if DEBUG
                "mtm_wip_application_test"
#else
                "mtm_wip_application"
#endif
            );
            set => _database = value;
        }

        private static string? _database;

        public static string WipServerAddress
        {
            get => _wipServerAddress ?? (
#if DEBUG
                GetLocalIpAddress() == "172.16.1.104" ? "172.16.1.104" : "localhost"
#else
                "172.16.1.104"
#endif
            );
            set => _wipServerAddress = value;
        }

        private static string? _wipServerAddress;

        public static string WipServerPort { get; set; } = "3306";

        /// <summary>
        /// Gets the local IP address to determine server selection in Debug mode
        /// </summary>
        private static string GetLocalIpAddress()
        {
            try
            {
                using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0);
                socket.Connect("8.8.8.8", 65530);
                var endPoint = socket.LocalEndPoint as IPEndPoint;
                return endPoint?.Address.ToString() ?? "localhost";
            }
            catch
            {
                return "localhost";
            }
        }

        #endregion
    }
}