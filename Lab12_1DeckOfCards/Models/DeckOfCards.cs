using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12_1DeckOfCards.Models
{
    public class Root
    {
        public bool success { get; set; }
        public string deck_id { get; set; }
        public List<Card> cards { get; set; }
        public int remaining { get; set; }
    }

    public class Card
    {
        public string code { get; set; }
        public string image { get; set; }
        public string value { get; set; }
        public string suit { get; set; }
    }
}
