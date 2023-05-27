using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace The_Stoic_Way.Classes
{
    internal class Quote
    {
        [JsonProperty("Text")]
        public string Text { get; set; }

        [JsonProperty("Author")]
        public string Author { get; set; }

        public Quote(string author, string text)
        {
            Text = text;
            Author = author;
        }
    }
}
