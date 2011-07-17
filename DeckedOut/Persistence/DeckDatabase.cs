using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeckedOut.Domain;

namespace DeckedOut.Persistence
{
    [Serializable]
    public class DeckDatabase
    {
        public virtual List<Deck> Decks { get; set; }
    }
}