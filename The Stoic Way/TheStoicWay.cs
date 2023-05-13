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
            //OpenAI_API is too complicated, will come back to it after main features have been implemented; for now, abandoning this feature due to complexity and lack of understanding

            //Open at machine start-up

            //Get quotes from JSON

            string folderName = "data";
            string fileName = "quotes.json";
            string pathName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folderName, fileName);

            try
            {
                List<Quote> quotes = JsonConvert.DeserializeObject<List<Quote>>(File.ReadAllText(pathName));

                Random random = new Random();
                Quote quote = quotes[random.Next(quotes.Count)];
                MessageBox.Show(quote.Text + quote.Author);
            }
            catch (FileNotFoundException nfex)
            {
                if(!File.Exists(pathName))
                {
                    MessageBox.Show("File Does Not Exist\n" + nfex.ToString());
                    Console.Write(nfex.ToString());
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error\n" + ex.ToString());
                Console.WriteLine(ex.ToString());
                Environment.Exit(0);
            }

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