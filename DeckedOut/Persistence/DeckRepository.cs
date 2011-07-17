using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeckedOut.Domain;
using System.Xml.Serialization;

namespace DeckedOut.Persistence
{
    public class DeckRepository : IDeckRepository
    {
        private DeckDatabase _db;

        protected virtual DeckDatabase Db
        {
            get
            {
                if (_db == null)
                    _db = LoadDb();

                return _db;
            }
        }

        public DeckRepository()
        {

        }

        protected virtual DeckDatabase LoadDb()
        {
            var deserialize = new XmlSerializer(typeof(DeckDatabase));
            return null;
        }

        public Deck Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Deck newDeck)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}