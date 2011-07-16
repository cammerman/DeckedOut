using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeckedOut.ViewModels
{
    public class DeckList
    {
        public DeckList()
        {
            Decks = new List<Deck>();
        }

        public virtual IEnumerable<Deck> Decks { get; set; }
    }
}