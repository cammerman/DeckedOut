using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeckedOut.Domain;
using System.Xml.Serialization;
using System.IO;

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
            var deserializer = new XmlSerializer(typeof(DeckDatabase));

            try
            {
                using (var fs = new FileStream(@"C:\DeckedOut\db.xml", FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return deserializer.Deserialize(fs) as DeckDatabase;
                }
            }
            catch (FileNotFoundException)
            {
                return new DeckDatabase { Decks = new List<Deck>() };
            }
        }

        public virtual IEnumerable<Deck> GetAll()
        {
            return Db.Decks;
        }

        public virtual Deck Get(int id)
        {
            return Db.Decks.FirstOrDefault(deck => deck.Id == id);
        }

        public virtual void Add(Deck newDeck)
        {
            if (newDeck.Id != 0)
                throw new ArgumentException("Cannot add a deck with an ID already specified");

            newDeck.Id =
                1 +
                Db.Decks
                    .Select(deck => deck.Id)
                    .DefaultIfEmpty(0)
                    .Max();

            Db.Decks.Add(newDeck);
        }

        public virtual void Remove(int id)
        {
            var deck = Get(id);

            if (deck != null)
                Db.Decks.Remove(deck);
        }

        protected virtual void Rollback()
        {
            _db = null;
        }

        protected virtual void Commit()
        {
            if (_db != null)
            {
                var serializer = new XmlSerializer(typeof(DeckDatabase));

                using (var fs = new FileStream(@"C:\DeckedOut\db.xml", FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    serializer.Serialize(fs, _db);
                }
            }
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Clean up managed resources
                Commit();
            }   

            // Clean up unmanaged resources
        }

        ~DeckRepository()
        {
            Dispose(false);
        }
    }
}