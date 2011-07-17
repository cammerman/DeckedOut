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

        public virtual List<Deck> Decks { get; set; }

        public virtual bool AnyDecksExist { get { return Decks.Any(); } }
    }
}