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
using System.Runtime.CompilerServices;

namespace The_Stoic_Way
{
    public partial class TheStoicWay : Form
    {
        private string activeTimer = "";
        private string workTimeInput = "";
        private string restTimeInput = "";
        private string pausedWorkTime = "";
        private string pausedRestTime = "";
        private int confirmationCount = 0;
        private Rectangle previousBounds;
        private FormWindowState previousWindowState;
        private TimeSpan workTimerValue = TimeSpan.Zero;
        private TimeSpan restTimerValue = TimeSpan.Zero;


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

        protected override void WndProc(ref Message m) //can also just be done using this in the _Load function; this.MaximizeBox = false;
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MAXIMIZE = 0xF030;

            if (m.Msg == WM_SYSCOMMAND && m.WParam == (IntPtr)SC_MAXIMIZE) return; // ignorer maximize system commands

            base.WndProc(ref m);
        }

        private void TheStoicWay_Load(object sender, EventArgs e)
        {
            previousWindowState = WindowState;
            previousBounds = Bounds;

            //Get quotes from JSON
            string pathName = "..\\..\\..\\data\\quotes.json";
            try
            {
                string file = File.ReadAllText(pathName);
                dynamic quotes = JsonConvert.DeserializeObject<List<Quote>>(file);
                Random random = new Random();
                int randomIndex = random.Next(quotes.Count);

                QuoteLabel.ForeColor = Color.FromArgb(47, 49, 48);
                QuoteLabel.Text =
                quotes[randomIndex].Text + "\n\n— " + quotes[randomIndex].Author;
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
                            Application.Exit();
                        else
                            e.Cancel = true;
                    }
                }
            }
        }

        private void WorkButton_Click(object sender, EventArgs e)
        {
            TimeEnabledFalse();
            activeTimer = "Work";
            string timeInput = WorkTime.Text;
            string restTimeInput = RestTime.Text;
            if (WorkTime.Text != "00:00:00" && TimeSpan.TryParseExact(timeInput, "hh\\:mm\\:ss", CultureInfo.InvariantCulture, out TimeSpan timerValue) && RestTime.Text != "00:00:00" && TimeSpan.TryParseExact(restTimeInput, "hh\\:mm\\:ss", CultureInfo.InvariantCulture, out TimeSpan restTimer))
            {
                // Set up and start the work timer
                WorkTime.Text = timeInput;
                workTimeInput = timeInput;
                workTimerValue = timerValue;
                WorkTimer.Start();
            }
            else
            {
                MessageBox.Show("Invalid Time Input");
                Reset();
            }

        }

        private void WorkTimer_Tick(object sender, EventArgs e)
        {
            if (WorkTimer.Enabled && RestTime.Text != "00:00:00")
            {
                workTimerValue = workTimerValue.Subtract(TimeSpan.FromSeconds(1));
                WorkTime.Text = workTimerValue.ToString(@"hh\:mm\:ss");

                if (workTimerValue.TotalSeconds <= 0)
                {
                    WorkTimer.Stop();
                    MessageBox.Show("Work Timer Stopped");
                    TimeEnabledFalse();
                    this.WindowState = FormWindowState.Minimized;
                    StartRestTimer();
                }
            }
        }

        private void StartRestTimer()
        {
            activeTimer = "Rest";

            string restTimeInput = RestTime.Text;
            if (TimeSpan.TryParseExact(restTimeInput, "hh\\:mm\\:ss", CultureInfo.InvariantCulture, out TimeSpan restTimer))
            {
                restTimerValue = restTimer;
                RestTimer.Start();
            }
        }

        private void RestTimer_Tick(object sender, EventArgs e)
        {
            activeTimer = "Rest";

            if (RestTimer.Enabled)
            {
                restTimerValue = restTimerValue.Subtract(TimeSpan.FromSeconds(1));
                RestTime.Text = restTimerValue.ToString(@"hh\:mm\:ss");

                if (restTimerValue.TotalSeconds <= 0)
                {
                    this.WindowState = previousWindowState;
                    this.Bounds = previousBounds;
                    RestTimer.Stop();
                    MessageBox.Show("Rest Timer Stopped");
                    WorkTime.Enabled = true;
                    RestTime.Enabled = true;
                }
            }
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            WorkButton.Enabled = false;
            TimeEnabledFalse();

            if (activeTimer == "Work")
            {
                if (WorkTimer.Enabled)
                    WorkTimer.Stop();
            }
            else if (activeTimer == "Rest")
            {
                if (RestTimer.Enabled)
                    RestTimer.Stop();
            }
        }


        private void ResumeButton_Click(object sender, EventArgs e)
        {
            TimeEnabledFalse();

            if (activeTimer == "Work")
            {
                if (!WorkTimer.Enabled)
                    WorkTimer.Start();
            }
            else if (activeTimer == "Rest")
            {
                if (!RestTimer.Enabled)
                    RestTimer.Start();
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Logo_Click(object sender, EventArgs e)
        {
            //Redirect to documentation files
        }

        private void WorkTime_Validating(object sender, CancelEventArgs e)
        {
            if (TimeSpan.TryParseExact(WorkTime.Text, "hh\\:mm\\:ss", CultureInfo.InvariantCulture, out TimeSpan workTimeValue) && TimeSpan.TryParseExact(RestTime.Text, "hh\\:mm\\:ss", CultureInfo.InvariantCulture, out TimeSpan restTimeValue))
            {
                TimeSpan maxTime = new TimeSpan(23, 59, 59);
                if (workTimeValue > maxTime && restTimeValue > maxTime)
                    WorkTime.Text = maxTime.ToString(@"hh\:mm\:ss"); // Reset the value to the maximum allowed value
            }
            else
                WorkTime.Text = string.Empty; // Invalid input, reset to empty string or default value
        }

        private void TimeEnabledFalse()
        {
            WorkTime.Enabled = false;
            RestTime.Enabled = false;
        }

        private void Reset()
        {
            if (!WorkTimer.Enabled && !RestTimer.Enabled) // if either of the timers are not on
            {
                WorkButton.Enabled = true;
                ResumeButton.Enabled = true;
                PauseButton.Enabled = true;
                ResetButton.Enabled = true;
                WorkTime.Enabled = true;
                RestTime.Enabled = true;
                WorkTime.Text = "00:00:00";
                RestTime.Text = "00:00:00";
            }
        }
    }
}