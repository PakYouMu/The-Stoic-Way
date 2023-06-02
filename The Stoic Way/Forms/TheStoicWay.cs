using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using OpenAI_API.Completions;
using OpenAI_API;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using The_Stoic_Way.Classes;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualBasic.ApplicationServices;
using OpenAI_API.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Reflection;
using Timer = System.Windows.Forms.Timer;
using System.Globalization;
using System.Timers;

namespace The_Stoic_Way
{
    public partial class TheStoicWay : Form
    {
        private int confirmationCount = 0;
        private TimeSpan workTimerValue = TimeSpan.Zero;
        private TimeSpan restTimerValue = TimeSpan.Zero;
        private string workTimeInput;
        private string restTimeInput;
        private string pausedWorkTime;
        private string pausedRestTime;
        private bool isWorkPaused = false;
        private bool isRestPaused = false;


        public TheStoicWay()
        {
            InitializeComponent();
        }

        //private list for exit confirmation messages
        private List<string> confirmationMessages = new List<string>
        {
            "Are you sure you want to quit?",
            "Are you really sure?",
            "Okay, Bye"
        };

        /*protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MAXIMIZE = 0xF030;

            if (m.Msg == WM_SYSCOMMAND && m.WParam == (IntPtr)SC_MAXIMIZE)
                return; // ignorer maximize system commands

            base.WndProc(ref m);
        }*/

        private void TheStoicWay_Load(object sender, EventArgs e)
        {
            //set up
            this.MaximizeBox = false;
            WorkTimer.Interval = 1000;
            RestTimer.Interval = 1000;
            WorkButton.Enabled = true;
            RestButton.Enabled = true;
            PauseButton.Enabled = true;
            ResetButton.Enabled = true;
            WorkTime.Text = "00:00:00";
            RestTime.Text = "00:00:00";

            //Get quotes from JSON
            string pathName = "..\\..\\..\\data\\quotes.json";
            string file = File.ReadAllText(pathName);
            try
            {
                dynamic quotes = JsonConvert.DeserializeObject<List<Quote>>(file);
                Random random = new Random();
                int randomIndex = random.Next(quotes.Count);

                //show text on the middle of the form
                QuoteLabel.ForeColor = Color.FromArgb(47, 49, 48);
                QuoteLabel.Text = "Choose someone whose way of life as well as words, and whose very face as mirroring the character that lies behind it, have won your approval.Be always pointing him out to yourself either as your guardian or as your model.This is a need, in my view, for someone as a standard against which our characters can measure themselves.Without a ruler to do it against you won't make the crooked straight." + "\n— " + "Seneca";
                //quotes[randomIndex].Text + "\n— " + quotes[randomIndex].Author;
            }
            catch (FileNotFoundException ex)
            {
                if (!File.Exists(pathName))
                {
                    MessageBox.Show("File Does Not Exist\n\n" + ex.ToString());
                    Console.Write(ex.ToString());
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error\n\n" + ex.ToString());
                Console.WriteLine(ex.ToString());
                Application.Exit();
            }
        }

        private void TheStoicWay_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (confirmationCount < confirmationMessages.Count)
                {
                    DialogResult result = MessageBox.Show(confirmationMessages[confirmationCount], "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        confirmationCount = 0;
                        e.Cancel = true;
                    }
                    else
                    {
                        confirmationCount++;

                        if (confirmationCount == confirmationMessages.Count) // This is the last confirmation, close the application
                            Application.Exit();
                        else
                            e.Cancel = true;
                    }
                }
            }
        }

        private void WorkButton_Click(object sender, EventArgs e)
        {
            string timeInput = WorkTime.Text;
            if (TimeSpan.TryParseExact(timeInput, "hh\\:mm\\:ss", CultureInfo.InvariantCulture, out TimeSpan timerValue))
            {
                // Set up and start the work timer
                WorkTime.Text = timeInput;
                workTimeInput = timeInput;
                workTimerValue = timerValue;
                WorkTimer.Start();
                isWorkPaused = false;
            }
            else
                MessageBox.Show("Invalid Work Time Input");
        }

        private void WorkTimer_Tick(object sender, EventArgs e)
        {
            if (!isWorkPaused)
            {
                workTimerValue = workTimerValue.Subtract(TimeSpan.FromSeconds(1));
                WorkTime.Text = workTimerValue.ToString(@"hh\:mm\:ss");

                if (workTimerValue.TotalSeconds <= 0)
                {
                    WorkTimer.Stop();
                    MessageBox.Show("Work Timer Stopped");

                    StartRestTimer();
                }
            }
        }

        private void RestButton_Click(object sender, EventArgs e)
        {
            /*RestButton.Enabled = false;
            string timeInput = RestTime.Text;
            if (TimeSpan.TryParseExact(timeInput, "hh\\:mm\\:ss", CultureInfo.InvariantCulture, out TimeSpan timerValue))
            {
                // Set up and start the rest timer
                RestTime.Text = timeInput;
                restTimerValue = timerValue;
                RestTimer.Start();
                isRestPaused = false;
            }
            else
                MessageBox.Show("Invalid Input");*/
        }

        private void StartRestTimer()
        {
            string restTimeInput = RestTime.Text;
            if (TimeSpan.TryParseExact(restTimeInput, "hh\\:mm\\:ss", CultureInfo.InvariantCulture, out TimeSpan restTimer))
            {
                restTimerValue = restTimer;
                RestTimer.Start();
                isRestPaused = false;
            }
            else
                MessageBox.Show("Invalid Rest Time Input");
        }

        private void RestTimer_Tick(object sender, EventArgs e)
        {
            if (!isRestPaused)
            {
                restTimerValue = restTimerValue.Subtract(TimeSpan.FromSeconds(1));
                RestTime.Text = restTimerValue.ToString(@"hh\:mm\:ss");

                if (restTimerValue.TotalSeconds <= 0)
                {
                    RestTimer.Stop();
                    MessageBox.Show("Rest Timer Stopped");
                }
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            // Reset the form to its initial state
            WorkButton.Enabled = true;
            RestButton.Enabled = true;
            PauseButton.Enabled = true;
            ResetButton.Enabled = true;
            WorkTime.Text = "00:00:00";
            RestTime.Text = "00:00:00";
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            if (sender == WorkButton)
            {
                if (isWorkPaused)
                {
                    // Resume the work timer
                    WorkTimer.Start();
                    WorkButton.Text = "Pause";
                    isWorkPaused = false;
                    WorkTime.Text = pausedWorkTime; // Set the previously paused work time
                }
                else
                {
                    // Pause the work timer
                    WorkTimer.Stop();
                    WorkButton.Text = "Resume";
                    isWorkPaused = true;
                    pausedWorkTime = WorkTime.Text; // Store the current work time
                }
            }
            else if (sender == RestButton)
            {
                if (isRestPaused)
                {
                    // Resume the rest timer
                    RestTimer.Start();
                    RestButton.Text = "Pause";
                    isRestPaused = false;
                    RestTime.Text = pausedRestTime; // Set the previously paused rest time
                }
                else
                {
                    // Pause the rest timer
                    RestTimer.Stop();
                    isRestPaused = true;
                    pausedRestTime = RestTime.Text; // Store the current rest time
                }
            }
        }

        private void Logo_Click(object sender, EventArgs e)
        {
            //Redirect to documentation files
        }

        private bool IsValidTimeInput(string timeInput)
        {
            // Define the format for the expected time input
            string timeFormat = "hh:mm:ss";

            // Parse the time input string and check if it is a valid time within the range
            if (TimeSpan.TryParseExact(timeInput, timeFormat, CultureInfo.InvariantCulture, out TimeSpan time))
            {
                // Check if the parsed time is within the valid range
                TimeSpan minTime = TimeSpan.Parse("00:00:00");
                TimeSpan maxTime = TimeSpan.Parse("23:59:59");
                if (time >= minTime && time <= maxTime)
                {
                    // The time input is valid within the specified range
                    return true;
                }
            }

            // The time input is either invalid or outside the specified range
            return false;
        }

        private void WorkTime_Validating(object sender, CancelEventArgs e)
        {
            if (TimeSpan.TryParseExact(WorkTime.Text, "hh\\:mm\\:ss", CultureInfo.InvariantCulture, out TimeSpan timeValue))
            {
                TimeSpan maxTime = new TimeSpan(23, 59, 59);
                if (timeValue > maxTime)
                {
                    // Reset the value to the maximum allowed value
                    WorkTime.Text = maxTime.ToString(@"hh\:mm\:ss");
                }
            }
            else
            {
                // Invalid input, reset to empty string or default value
                WorkTime.Text = string.Empty;
            }
        }

        
    }
}

/*
private void startButton_Click(object sender, EventArgs e)
{
string input = maskedTextBox.Text;

if (IsValidTimeInput(input))
{
// Parse the input and calculate the total duration
int hours = int.Parse(input.Substring(0, 2));
int minutes = int.Parse(input.Substring(3, 2));
int seconds = int.Parse(input.Substring(6, 2));
duration = new TimeSpan(hours, minutes, seconds);

// Disable the MaskedTextBox and Start button while the countdown is running
maskedTextBox.Enabled = false;
startButton.Enabled = false;

// Start the countdown timer
timer.Interval = 1000; // 1 second
timer.Tick += Timer_Tick;
timer.Start();
}
else
{
MessageBox.Show("Invalid time format. Please enter the time in the format of hours:minutes:seconds.");
}
}

private bool IsValidTimeInput(string input)
{
// Validate the input against the desired time format
Regex regex = new Regex(@"^\d{2}:\d{2}:\d{2}$");
return regex.IsMatch(input);
}

private void Timer_Tick(object sender, EventArgs e)
{
// Update the remaining time label
elapsedTime = elapsedTime.Add(TimeSpan.FromSeconds(1));
TimeSpan remainingTime = duration - elapsedTime;

if (remainingTime.TotalSeconds <= 0)
{
// Countdown complete
timer.Stop();
MessageBox.Show("Countdown complete!");
ResetForm();
}
else
{
label.Text = $"Time Remaining: {remainingTime.Hours:D2}:{remainingTime.Minutes:D2}:{remainingTime.Seconds:D2}";
}
}

private void ResetForm()
{
// Reset the form to its initial state
maskedTextBox.Enabled = true;
startButton.Enabled = true;
maskedTextBox.Text = "00:00:00";
elapsedTime = TimeSpan.Zero;
label.Text = "Time Remaining: 00:00:00";
}

*/

//can be used in a later patch
/*private string GetInstallPathFromRegistry()
{
    // Open the registry key that contains the installation path
    RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\MyApplication\\AppPath");

    // Check if the key exists
    if (key != null)
    { 147, 159, 135
        // Get the value of the "Installed" entry
        string installPath = (string)key.GetValue("Installed");

        // Close the key
        key.Close();

        // Return the installation path
        return installPath;
    }
    else
    {
        // Return null if the key does not exist
        return null;
    }
}*/