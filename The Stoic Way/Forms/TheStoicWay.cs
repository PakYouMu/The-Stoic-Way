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
            string pathName = "..\\..\\..\\data\\quotes.json";
            string file = File.ReadAllText(pathName);
            try
            {
                dynamic quotes = JsonConvert.DeserializeObject<List<Quote>>(file);
                Random random = new Random();
                int randomIndex = random.Next(quotes.Count);
                //showing on MessageBox for testing purposes only
                MessageBox.Show(quotes[randomIndex].Text + "\n- " + quotes[randomIndex].Author);

                //show text on the middle of the form

            }
            catch (FileNotFoundException ex)
            {
                if (!File.Exists(pathName))
                {
                    MessageBox.Show("File Does Not Exist\n" + ex.ToString());
                    Console.Write(ex.ToString());
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

        //can be used in a later patch
        /*private string GetInstallPathFromRegistry()
        {
            // Open the registry key that contains the installation path
            RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\MyApplication\\AppPath");

            // Check if the key exists
            if (key != null)
            {
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

        private void TheStoicWay_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall && e.CloseReason != CloseReason.WindowsShutDown)
            {
                e.Cancel = true;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}