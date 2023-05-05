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
            CompletionRequest request = new CompletionRequest();
            request.Prompt = "I am a Stoic. A follower or practitioner of an ancient Philosophy developed  by the Greeks, and perfected by the Romans. It has long been since misattributed to being the philosophy of showing no emotion, however, in truth it is the philosophy and way of life that focuses in wisdom, justice, moderation, and courage. There have been multiple philosophers, men, women, leaders, slaves, and the such that have contributed to such philosophy over the thousands of years it has existed.Give me one Stoic quote.";
            request.Model = OpenAI_API.Models.Model.DavinciText;
            var completions = openAI.Completions.CreateCompletionAsync(request);

            foreach(var completion in completions.Result.Completions)
            {
                string filePath = @"C:\quotes.txt";
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine(completion.Text);
                }
            }

            

            /*CompletionRequest completionRequest = new CompletionRequest
            {
                Prompt = "I am a Stoic. A follower or practitioner of an ancient Philosophy developed  by the Greeks, and perfected by the Romans. It has long been since misattributed to being the philosophy of showing no emotion, however, in truth it is the philosophy and way of life that focuses in wisdom, justice, moderation, and courage. There have been multiple philosophers, men, women, leaders, slaves, and the such that have contributed to such philosophy over the thousands of years it has existed. Give me one Stoic quote.",

                Model = "text-davinci-003",
                MaxTokens = 100,
            };*/
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