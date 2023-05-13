using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace The_Stoic_Way
{
    internal class Quote
    {
        public string Text { get; set; }
        public string Author { get; set; }

        public Quote(string author, string text)
        {
            Text = text;
            Author = author;
        }
        
        //Unsure yet
        /*public static List<Quote>? GetQuotes(string pathName)
        {
            List<Quote> quotes = new List<Quote>();
            try
            {
                quotes = JsonConvert.DeserializeObject<List<Quote>>(File.ReadAllText(pathName));
                return quotes;
            }
            catch (Exception ex)
            {
                if(quotes == null)
                    MessageBox.Show("There Are No Quotes!" + ex.Message);
                return null;
            }
        }*/
    }
}
