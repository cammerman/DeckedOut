using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckedOut.Domain
{
    public interface IDeckRepository : IDisposable
    {
        IEnumerable<Deck> GetAll();
        Deck Get(int id);
        void Add(Deck newDeck);
    }
}
