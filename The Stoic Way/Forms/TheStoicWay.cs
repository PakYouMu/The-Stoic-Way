using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Timers;
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

namespace The_Stoic_Way
{
    public partial class TheStoicWay : Form
    {
        private int confirmationCount = 0;
        private TimeSpan duration;
        private TimeSpan elapsedTime;

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

        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020;
            const int SC_MAXIMIZE = 0xF030; // come back to this later and create it such as like FormClosing

            if (m.Msg == WM_SYSCOMMAND && (m.WParam == (IntPtr)SC_MINIMIZE || m.WParam == (IntPtr)SC_MAXIMIZE))
                return; // Ignore the minimize and maximize system commands

            base.WndProc(ref m);
        }

        private void TheStoicWay_Load(object sender, EventArgs e)
        {
            //OpenAI_API is too complicated, will come back to it after main features have been implemented; for now, abandoning this feature due to complexity and lack of understanding
            //set up
            this.MaximizeBox = false;

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
                QuoteLabel.Text = quotes[randomIndex].Text + "\n — " + quotes[randomIndex].Author;
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

                        if (confirmationCount == confirmationMessages.Count)
                            Application.Exit(); // This is the last confirmation, close the application
                        else
                            e.Cancel = true;
                    }
                }
            }

        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            // Reset the form to its initial state
            WorkTimer.Enabled = true;
            RestTimer.Enabled = true;
            WorkTimer.Text = "00:00:00";
            RestTimer.Text = "00:00:00";
            WorkTime.Text = "00:00:00";
            RestTime.Text = "00:00:00";
            elapsedTime = TimeSpan.Zero;
            WorkTimer.Text = "00:00:00";
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

    }
}

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