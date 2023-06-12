using System.Timers;
using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using System.Reflection;


namespace The_Stoic_Way.Classes
{
    public class ScheduledTaskManager
    {
        private const string TaskName = "The Stoic Way";
        private const string Description = "Start The Stoic Way on system startup";

        public static void CreateTask()
        {
            using (TaskService taskService = new TaskService())
            {
                TaskDefinition taskDefinition = taskService.NewTask();
                taskDefinition.RegistrationInfo.Description = Description;

                taskDefinition.Triggers.Add(new BootTrigger());
                taskDefinition.Actions.Add(new ExecAction(Assembly.GetExecutingAssembly().Location));

                taskService.RootFolder.RegisterTaskDefinition(TaskName, taskDefinition);
            }
        }

        public static void RemoveTask()
        {
            using (TaskService taskService = new TaskService())
            {
                taskService.RootFolder.DeleteTask(TaskName, false);
            }
        }
    }

    public class AutostartManager
    {
        private const string AppName = "The Stoic Way";
        private const string RunKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

        public static void AddToAutostart()
        {
            string exePath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            RegistryKey startupKey = Registry.CurrentUser.OpenSubKey(RunKey, true);
            startupKey.SetValue(AppName, exePath);
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
            ScheduledTaskManager.CreateTask();

            // Remove from autostart
            // AutostartManager.RemoveFromAutostart();
            ApplicationConfiguration.Initialize();
            Application.Run(new TheStoicWay());
        }
    }
}