using System;
using System.Collections.Generic;
using System.Text;

namespace DadJokesLibrary
{ 
    public class DadJokes
    {
        public int Limit { get; set; }
        public List<DadJokeItem> Results { get; set; }
        public string Search_Term { get; set; }
        public string Status { get; set; }
        public int Total_Jokes { get; set; }
    }
}
