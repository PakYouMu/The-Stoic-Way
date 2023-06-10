using System.Timers;
using Microsoft.Win32;

namespace The_Stoic_Way.Classes
{
    public class AutostartManager
    {
        private const string AppName = "The Stoic Way";
        private const string RunKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

        public static void AddToAutostart()
        {
            RegistryKey startupKey = Registry.CurrentUser.OpenSubKey(RunKey, true);
            startupKey.SetValue(AppName, System.Reflection.Assembly.GetExecutingAssembly().Location);
            startupKey.Close();
        }

        public static void RemoveFromAutostart()
        {
            RegistryKey startupKey = Registry.CurrentUser.OpenSubKey(RunKey, true);
            startupKey.DeleteValue(AppName, false);
            startupKey.Close();
        }
    }

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            // Add to autostart
            AutostartManager.AddToAutostart();

            // Remove from autostart
            // AutostartManager.RemoveFromAutostart();
            ApplicationConfiguration.Initialize();
            Application.Run(new TheStoicWay());
        }
    }
}