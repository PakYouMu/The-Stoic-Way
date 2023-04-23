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

namespace The_Stoic_Way
{
    public partial class TheStoicWay : Form
    {


        public TheStoicWay()
        {
            InitializeComponent();
        }

        private void TheStoicWay_Load(object sender, EventArgs e)
        {
            var openAI = new OpenAIAPI("sk - xF4xGMEmYTcwCuSO67lCT3BlbkFJL6g1H06fcHSCLEZxAYvN");
            CompletionRequest completionRequest = new CompletionRequest
            {
                Prompt = "I am a Stoic. A follower or practitioner of an ancient Philosophy developed  by the Greeks, and perfected by the Romans. It has long been since misattributed to being the philosophy of showing no emotion, however, in truth it is the philosophy and way of life that focuses in wisdom, justice, moderation, and courage. There have been multiple philosophers, men, women, leaders, slaves, and the such that have contributed to such philosophy over the thousands of years it has existed. Give me one Stoic quote that reminds me how great life is",

                Model = "text-davinci-003",
                MaxTokens = 1000,
            };
        }

        private void TheStoicWay_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall && e.CloseReason != CloseReason.WindowsShutDown)
            {
                e.Cancel = true;
            }
        }
    }
}